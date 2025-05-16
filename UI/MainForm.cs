using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TrackTagger.Models;
using TrackTagger.Modules;
using TrackTagger.Utils;

namespace TrackTagger.UI;

public partial class MainForm : Form {

	private readonly ListViewColumnSorter listViewColumnSorter = new();
	private readonly List<string> supportedExtensions = [".mp3"];
	private readonly Image defaultAlbumArt;

	public MainForm() {
		InitializeComponent();
		defaultAlbumArt = albumArtPicture.Image;
	}

	private void MainForm_Load(object sender, EventArgs e) {
		trackListView.ListViewItemSorter = listViewColumnSorter;
	}

	private void MainForm_DragEnter(object sender, DragEventArgs e) {
		if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
			e.Effect = DragDropEffects.Link;
		}
	}

	private void MainForm_DragDrop(object sender, DragEventArgs e) {
		string[] filePaths = (string[]) e.Data.GetData(DataFormats.FileDrop);
		ImportFiles(filePaths);
	}

	private void ImportFolderButton_Click(object sender, EventArgs e) {
		importFolderDialog.SelectedPath = Environment.CurrentDirectory;
		if (importFolderDialog.ShowDialog() == DialogResult.OK) {
			string[] filePaths = Directory.GetFiles(importFolderDialog.SelectedPath, "*.mp3", importSubfoldersCheckBox.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
			ImportFiles(filePaths);
		}
	}

	private void ImportFiles(string[] filePaths) {
		foreach (string filePath in filePaths) {
			if (Path.GetExtension(filePath) != ".mp3") {
				continue;
			}
			TrackListViewItem item = new(this, filePath);
			trackListView.Items.Add(item);
			if (matchOnImportCheckBox.Checked) {
				item.StartSearchThread();
			} else {
				item.SetStatus(-1, "Unmatched");
			}
		}
	}

	private void UnmatchButton_Click(object sender, EventArgs e) {
		foreach (TrackListViewItem item in GetTargetItems()) {
			if (item.Status == 1) {
				item.SetStatus(-1, "Unmatched");
			}
		}
	}

	private void MatchButton_Click(object sender, EventArgs e) {
		foreach (TrackListViewItem item in GetTargetItems()) {
			if (item.Status == -1) {
				item.ResetSearchString();
				item.StartSearchThread();
			}
		}
	}

	private void TagButton_Click(object sender, EventArgs e) {
		Enabled = false;
		foreach (TrackListViewItem item in GetTargetItems()) {
			TagItem(item);
		}
		Enabled = true;
	}

	private IList GetTargetItems() {
		return trackListView.SelectedItems.Count > 0 ? trackListView.SelectedItems : trackListView.Items;
	}

	private void TagItem(TrackListViewItem item) {
		if (item.Status != 1) {
			return;
		}
		try {
			DateTime lastWriteTime = File.GetLastWriteTime(item.FilePath);
			TagLib.File tagLibFile = TagLib.File.Create(item.FilePath);
			if (clearExistingTagsCheckBox.Checked) {
				tagLibFile.RemoveTags(TagLib.TagTypes.AllTags);
				tagLibFile.Save();
				tagLibFile.Dispose();
				tagLibFile = TagLib.File.Create(item.FilePath);
			}
			Track track = item.Tracks[item.SelectedTrackIndex];
			if (albumArtCheckBox.Checked && File.Exists(track.AlbumArtFilePath)) {
				tagLibFile.Tag.Pictures = [new TagLib.Picture(track.AlbumArtFilePath)];
			}
			if (artistCheckBox.Checked) {
				tagLibFile.Tag.Performers = [track.Artist];
			}
			if (titleCheckBox.Checked) {
				tagLibFile.Tag.Title = track.Title;
			}
			if (albumCheckBox.Checked) {
				tagLibFile.Tag.Album = track.Album;
			}
			if (yearCheckBox.Checked) {
				tagLibFile.Tag.Year = track.Year;
			}
			if (genreCheckBox.Checked) {
				tagLibFile.Tag.Genres = [track.Genre];
			}
			if (trackNumberCheckBox.Checked) {
				tagLibFile.Tag.Track = track.TrackNumber;
				tagLibFile.Tag.TrackCount = track.TrackCount;
			}
			if (discNumberCheckBox.Checked) {
				tagLibFile.Tag.Disc = track.DiscNumber;
				tagLibFile.Tag.DiscCount = track.DiscCount;
			}
			tagLibFile.RemoveTags(TagLib.TagTypes.AllTags & ~TagLib.TagTypes.Id3v2);
			tagLibFile.Save();
			tagLibFile.Dispose();
			File.SetLastWriteTime(item.FilePath, lastWriteTime);
			if (renameFilesCheckBox.Checked) {
				string newFileName = track.PopulateTemplate(namingSchemeTextBox.Text);
				string newRootFolder = track.PopulateTemplate(rootFolderTextBox.Text).Replace("%originalFolder%", Path.GetDirectoryName(item.FilePath));
				if (!Directory.Exists(newRootFolder)) {
					Directory.CreateDirectory(newRootFolder);
				}
				string newFilePath = string.Concat(Path.Join(newRootFolder, newFileName).Split(Path.GetInvalidPathChars())).Trim();
				File.Move(item.FilePath, newFilePath);
			}
			item.Remove();
		} catch (Exception e) {
			item.SetStatus(-1, $"Error: {e.Message}");
		}
	}

	public void UpdateSearchControls() {
		if (trackListView.SelectedItems.Count > 0) {
			TrackListViewItem item = (TrackListViewItem) trackListView.SelectedItems[0];
			queryTextBox.Text = item.Query;
			queryTextBox.Enabled = item.Status != 0;
			if (item.Status == 1) {
				tracksDropDown.Items.Clear();
				foreach (Track track in item.Tracks) {
					tracksDropDown.Items.Add(track.OriginalArtist + " - " + track.OriginalTitle);
				}
				tracksDropDown.Enabled = true;
				tracksDropDown.SelectedIndex = item.SelectedTrackIndex;
			} else {
				tracksDropDown.Items.Clear();
				albumArtPicture.Image = defaultAlbumArt;
				tracksDropDown.Enabled = false;
			}
		} else {
			queryTextBox.Enabled = false;
			tracksDropDown.Enabled = false;
			queryTextBox.Text = "";
			tracksDropDown.Items.Clear();
			albumArtPicture.Image = defaultAlbumArt;
		}
	}

	private void QueryTextBox_KeyDown(object sender, KeyEventArgs e) {
		if (e.KeyCode == Keys.Enter) {
			e.SuppressKeyPress = true;
			foreach (TrackListViewItem item in trackListView.SelectedItems) {
				item.Query = queryTextBox.Text;
				if (item.Status != 0) {
					item.StartSearchThread();
				}
			}
		}
	}

	private void TracksDropDown_SelectedIndexChanged(object sender, EventArgs e) {
		TrackListViewItem item = (TrackListViewItem) trackListView.SelectedItems[0];
		item.SelectedTrackIndex = tracksDropDown.SelectedIndex;
		item.UpdateSubItems();
		try {
			albumArtPicture.Load(item.Tracks[item.SelectedTrackIndex].AlbumArtFilePath);
		} catch {
			albumArtPicture.Image = defaultAlbumArt;
		}
	}

	private void TrackListView_SelectedIndexChanged(object sender, EventArgs e) {
		if (trackListView.SelectedItems.Count > 0) {
			matchButton.Text = "Match Selected";
			unmatchButton.Text = "Unmatch Selected";
			tagButton.Text = "Tag Selected Matched";
		} else {
			matchButton.Text = "Match All";
			unmatchButton.Text = "Unmatch All";
			tagButton.Text = "Tag All Matched";
		}
		UpdateSearchControls();
	}

	private void TrackListView_KeyDown(object sender, KeyEventArgs e) {
		if (e.KeyCode == Keys.Delete) {
			foreach (TrackListViewItem item in trackListView.SelectedItems) {
				item.Remove();
			}
		} else if (e.KeyCode == Keys.A && e.Control) {
			foreach (TrackListViewItem item in trackListView.Items) {
				item.Selected = true;
			}
		} else if (e.KeyCode == Keys.Escape) {
			trackListView.SelectedItems.Clear();
		}
	}

	private void TrackListView_ColumnClick(object sender, ColumnClickEventArgs e) {
		if (e.Column == listViewColumnSorter.SortColumn) {
			listViewColumnSorter.Order = listViewColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
		} else {
			listViewColumnSorter.SortColumn = e.Column;
			listViewColumnSorter.Order = SortOrder.Ascending;
		}
		trackListView.Sort();
	}

	private void AlbumArtPicture_DoubleClick(object sender, EventArgs e) {
		if (trackListView.SelectedItems.Count > 0) {
			TrackListViewItem item = (TrackListViewItem) trackListView.SelectedItems[0];
			using Process process = new();
			process.StartInfo.FileName = "explorer";
			process.StartInfo.Arguments = "\"" + item.Tracks[item.SelectedTrackIndex].AlbumArtFilePath + "\"";
			process.Start();
		}
	}

}
