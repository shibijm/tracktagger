using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TrackTagger.Models;
using TrackTagger.Modules;
using TrackTagger.Utils;

namespace TrackTagger.UI;

public partial class MainForm : Form {

	private readonly List<TrackListViewItem> items = [];
	public string tempDirectory;
	private readonly ListViewColumnSorter listViewColumnSorter = new();

	public MainForm() {
		InitializeComponent();
		tempDirectory = Path.GetTempPath() + "TrackTagger";
		Directory.CreateDirectory(tempDirectory);
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
		string[] droppedFiles = (string[]) e.Data.GetData(DataFormats.FileDrop);
		ImportFiles(droppedFiles);
	}

	private void ImportFolderButton_Click(object sender, EventArgs e) {
		importFolderDialog.SelectedPath = Environment.CurrentDirectory;
		DialogResult result = importFolderDialog.ShowDialog();
		if (result == DialogResult.OK) {
			string[] files = Directory.GetFiles(importFolderDialog.SelectedPath, "*.mp3", importSubfoldersCheckBox.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
			ImportFiles(files);
		}
	}

	private void ImportFiles(string[] files) {
		foreach (string filePath in files) {
			if (Directory.Exists(filePath)) {
				ImportFiles(Directory.GetFiles(filePath, "*.mp3", importSubfoldersCheckBox.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
			} else if (Path.GetExtension(filePath) == ".mp3") {
				TrackListViewItem item = new(this, filePath);
				trackListView.Items.Add(item);
				items.Add(item);
				if (matchOnImportCheckBox.Checked) {
					item.StartThread();
				} else {
					item.SetStatus(-1, "Unmatched");
				}
			}
		}
	}

	public void UpdateSearchControls() {
		if (InvokeRequired) {
			Invoke(new Action(() => UpdateSearchControls()));
		} else {
			if (trackListView.SelectedItems.Count > 0) {
				TrackListViewItem item = (TrackListViewItem) trackListView.SelectedItems[0];
				searchTextBox.Text = item.searchString;
				searchTextBox.Enabled = item.status != 0;
				if (item.status == 1) {
					tracksDropDown.Items.Clear();
					foreach (Track track in item.tracks) {
						tracksDropDown.Items.Add(track.OriginalArtist + " - " + track.OriginalTitle);
					}
					tracksDropDown.Enabled = true;
					tracksDropDown.SelectedIndex = item.index;
				} else {
					tracksDropDown.Items.Clear();
					albumArtPicture.Image = Properties.Resources.DefaultAlbumArt;
					tracksDropDown.Enabled = false;
				}
			} else {
				searchTextBox.Enabled = false;
				tracksDropDown.Enabled = false;
				searchTextBox.Text = "";
				tracksDropDown.Items.Clear();
				albumArtPicture.Image = Properties.Resources.DefaultAlbumArt;
			}
		}
	}

	private void SearchBox_KeyDown(object sender, KeyEventArgs e) {
		if (e.KeyCode == Keys.Enter) {
			e.SuppressKeyPress = true;
			foreach (TrackListViewItem item in trackListView.SelectedItems) {
				item.searchString = searchTextBox.Text;
				if (item.status != 0) {
					item.StartThread();
				}
			}
		}
	}

	private void TracksDropDown_SelectedIndexChanged(object sender, EventArgs e) {
		TrackListViewItem item = (TrackListViewItem) trackListView.SelectedItems[0];
		item.index = tracksDropDown.SelectedIndex;
		item.UpdateListViewItem();
		try {
			albumArtPicture.Load(item.tracks[item.index].AlbumArtFilePath);
		} catch {
			albumArtPicture.Image = Properties.Resources.DefaultAlbumArt;
		}
	}

	private void UnmatchButton_Click(object sender, EventArgs e) {
		dynamic target = trackListView.SelectedItems.Count > 0 ? trackListView.SelectedItems : trackListView.Items;
		foreach (TrackListViewItem item in target) {
			if (item.status == 1) {
				item.SetStatus(-1, "Unmatched");
			}
		}
	}

	private void MatchButton_Click(object sender, EventArgs e) {
		dynamic target = trackListView.SelectedItems.Count > 0 ? trackListView.SelectedItems : trackListView.Items;
		foreach (TrackListViewItem item in target) {
			if (item.status == -1) {
				item.ResetSearchString();
				item.StartThread();
			}
		}
	}

	private void FilesListView_SelectedIndexChanged(object sender, EventArgs e) {
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

	private void FilesListView_KeyDown(object sender, KeyEventArgs e) {
		if (e.KeyCode == Keys.Delete) {
			foreach (TrackListViewItem item in trackListView.SelectedItems) {
				RemoveItem(item);
			}
		} else if (e.KeyCode == Keys.A && e.Control) {
			foreach (TrackListViewItem item in trackListView.Items) {
				item.Selected = true;
			}
		} else if (e.KeyCode == Keys.Escape) {
			trackListView.SelectedIndices.Clear();
		}
	}

	private void TagButton_Click(object sender, EventArgs e) {
		Enabled = false;
		dynamic target = trackListView.SelectedItems.Count > 0 ? trackListView.SelectedItems : trackListView.Items;
		foreach (TrackListViewItem item in target) {
			TagItem(item);
		}
		Enabled = true;
	}

	private void TagItem(TrackListViewItem item) {
		if (item.status == 1) {
			try {
				DateTime lastWriteTime = File.GetLastWriteTime(item.filePath);
				TagLib.File tagLibFile = TagLib.File.Create(item.filePath);
				if (clearExistingTagsCheckBox.Checked) {
					tagLibFile.RemoveTags(TagLib.TagTypes.AllTags);
					tagLibFile.Save();
					tagLibFile = TagLib.File.Create(item.filePath);
				}
				Track track = item.tracks[item.index];
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
				tagLibFile.RemoveTags(TagLib.TagTypes.AllTags & ~TagLib.TagTypes.Id3v2);
				tagLibFile.Save();
				File.SetLastWriteTime(item.filePath, lastWriteTime);
				if (renameFilesCheckBox.Checked) {
					string newFileName = namingSchemeTextBox.Text.Replace(".mp3", "").Replace("%artist%", track.Artist).Replace("%title%", track.Title).Replace("%album%", track.Album).Replace("%year%", track.Year.ToString()).Replace("%genre%", track.Genre).Replace("%track%", track.TrackNumber.ToString().PadLeft(2, '0')).Replace("%trackCount%", track.TrackCount.ToString().PadLeft(2, '0')) + ".mp3";
					newFileName = string.Join("", newFileName.Split(Path.GetInvalidFileNameChars()));
					string newRootFolder = rootFolderTextBox.Text.Replace("%originalFolder%", Path.GetDirectoryName(item.filePath)).Trim().Replace("%artist%", track.Artist).Replace("%title%", track.Title).Replace("%album%", track.Album).Replace("%year%", track.Year.ToString()).Replace("%genre%", track.Genre).Replace("%track%", track.TrackNumber.ToString().PadLeft(2, '0')).Replace("%trackCount%", track.TrackCount.ToString().PadLeft(2, '0'));
					string newFilePath = newRootFolder + "\\" + newFileName;
					Directory.CreateDirectory(newRootFolder);
					File.Move(item.filePath, newFilePath);
				}
				RemoveItem(item);
			} catch (Exception e) {
				item.SetStatus(-1, "Error: " + e.Message);
			}
		}
	}

	private void RemoveItem(TrackListViewItem item) {
		item.Remove();
		items.Remove(item);
	}

	private void FilesListView_ColumnClick(object sender, ColumnClickEventArgs e) {
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
			process.StartInfo.Arguments = "\"" + item.tracks[item.index].AlbumArtFilePath + "\"";
			process.Start();
		}
	}

}
