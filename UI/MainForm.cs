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
	private readonly List<string> supportedExtensions = [".mp3", ".flac", ".m4a"];
	private readonly Image defaultAlbumArt;
	private bool suspendTlvUpdates = false;

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
		string[] paths = (string[]) e.Data.GetData(DataFormats.FileDrop);
		foreach (string path in paths) {
			if (Directory.Exists(path)) {
				ImportDirectory(path);
			} else {
				ImportFiles([path]);
			}
		}
	}

	private void ImportFolderButton_Click(object sender, EventArgs e) {
		importFolderDialog.SelectedPath = Environment.CurrentDirectory;
		if (importFolderDialog.ShowDialog() == DialogResult.OK) {
			ImportDirectory(importFolderDialog.SelectedPath);
		}
	}

	private void ImportDirectory(string path) {
		ImportFiles(Directory.EnumerateFiles(path, "*.*", importSubfoldersCheckBox.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
	}

	private void ImportFiles(IEnumerable<string> filePaths) {
		foreach (string filePath in filePaths) {
			if (!supportedExtensions.Contains(Path.GetExtension(filePath))) {
				continue;
			}
			TrackListViewItem item = new(filePath, trackListView.Columns.Count);
			trackListView.Items.Add(item);
			item.StatusChanged += (sender, e) => {
				if (item.Selected) {
					UpdateSearchControls();
				}
			};
			if (matchOnImportCheckBox.Checked) {
				item.Match();
			}
		}
	}

	private void UnmatchButton_Click(object sender, EventArgs e) {
		foreach (TrackListViewItem item in GetTargetItems()) {
			item.Unmatch();
		}
	}

	private void MatchButton_Click(object sender, EventArgs e) {
		foreach (TrackListViewItem item in GetTargetItems()) {
			item.Match();
		}
	}

	private void TagButton_Click(object sender, EventArgs e) {
		Enabled = false;
		TaggingOptions options = new() {
			ClearExistingTags = clearExistingTagsCheckBox.Checked,
			UpdateAlbumArt = albumArtCheckBox.Checked,
			UpdateArtist = artistCheckBox.Checked,
			UpdateTitle = titleCheckBox.Checked,
			UpdateAlbum = albumCheckBox.Checked,
			UpdateYear = yearCheckBox.Checked,
			UpdateGenre = genreCheckBox.Checked,
			UpdateTrackNumber = trackNumberCheckBox.Checked,
			UpdateDiscNumber = discNumberCheckBox.Checked,
			RenameFiles = renameFilesCheckBox.Checked,
			BasePathTemplate = basePathTemplateTextBox.Text.Trim(),
			FileNameTemplate = fileNameTemplateTextBox.Text.Trim(),
		};
		foreach (TrackListViewItem item in GetTargetItems()) {
			bool tagged = item.TagFile(options);
			if (tagged) {
				trackListView.Items.Remove(item);
			}
		}
		Enabled = true;
	}

	private IList GetTargetItems() {
		return trackListView.SelectedItems.Count > 0 ? trackListView.SelectedItems : trackListView.Items;
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

	private void TrackListView_SelectedIndexChanged(object sender, EventArgs e) {
		if (suspendTlvUpdates) {
			return;
		}
		bool hasSelectedItems = trackListView.SelectedItems.Count > 0;
		matchButton.Text = hasSelectedItems ? "Match Selected" : "Match All";
		unmatchButton.Text = hasSelectedItems ? "Unmatch Selected" : "Unmatch All";
		tagButton.Text = hasSelectedItems ? "Tag Selected Matched" : "Tag All Matched";
		UpdateSearchControls();
	}

	private void UpdateSearchControls() {
		tracksDropDown.Items.Clear();
		albumArtPicture.Image = defaultAlbumArt;
		if (trackListView.SelectedItems.Count > 0) {
			TrackListViewItem item = (TrackListViewItem) trackListView.SelectedItems[0];
			queryTextBox.Text = item.Query;
			queryTextBox.Enabled = item.Status != 0;
			if (item.Status == 1) {
				foreach (Track track in item.Tracks) {
					tracksDropDown.Items.Add($"{track.OriginalArtist} - {track.OriginalTitle}");
				}
				tracksDropDown.SelectedIndex = item.SelectedTrackIndex;
				tracksDropDown.Enabled = true;
			} else {
				tracksDropDown.Enabled = false;
			}
		} else {
			queryTextBox.Enabled = false;
			tracksDropDown.Enabled = false;
			queryTextBox.Text = "";
		}
	}

	private void RunWithSuspendedTlvUpdates(Action action) {
		suspendTlvUpdates = true;
		action();
		suspendTlvUpdates = false;
		TrackListView_SelectedIndexChanged(null, null);
	}

	private void TrackListView_KeyDown(object sender, KeyEventArgs e) {
		if (e.KeyCode == Keys.Delete) {
			RunWithSuspendedTlvUpdates(() => {
				foreach (TrackListViewItem item in trackListView.SelectedItems) {
					trackListView.Items.Remove(item);
				}
			});
		} else if (e.KeyCode == Keys.A && e.Control) {
			RunWithSuspendedTlvUpdates(() => {
				foreach (TrackListViewItem item in trackListView.Items) {
					item.Selected = true;
				}
			});
		} else if (e.KeyCode == Keys.Escape) {
			RunWithSuspendedTlvUpdates(() => trackListView.SelectedItems.Clear());
		} else if (e.KeyCode == Keys.Enter) {
			foreach (TrackListViewItem item in trackListView.SelectedItems) {
				LaunchFile(item.FilePath);
			}
		}
	}

	private void QueryTextBox_KeyDown(object sender, KeyEventArgs e) {
		if (e.KeyCode != Keys.Enter) {
			return;
		}
		e.SuppressKeyPress = true;
		foreach (TrackListViewItem item in trackListView.SelectedItems) {
			item.Match(queryTextBox.Text);
		}
	}

	private void TracksDropDown_SelectedIndexChanged(object sender, EventArgs e) {
		TrackListViewItem item = (TrackListViewItem) trackListView.SelectedItems[0];
		item.SetSelectedTrackIndex(tracksDropDown.SelectedIndex);
		try {
			albumArtPicture.Load(item.SelectedTrack.AlbumArtFilePath);
		} catch {
			albumArtPicture.Image = defaultAlbumArt;
		}
	}

	private void AlbumArtPicture_DoubleClick(object sender, EventArgs e) {
		if (trackListView.SelectedItems.Count > 0) {
			TrackListViewItem item = (TrackListViewItem) trackListView.SelectedItems[0];
			if (item.Status == 1) {
				LaunchFile(item.SelectedTrack.AlbumArtFilePath);
			}
		}
	}

	private void TrackListView_MouseDoubleClick(object sender, MouseEventArgs e) {
		ListViewItem item = trackListView.GetItemAt(e.X, e.Y);
		if (item != null) {
			LaunchFile(((TrackListViewItem) item).FilePath);
		}
	}

	private static void LaunchFile(string filePath) {
		ProcessStartInfo startInfo = new(filePath) { UseShellExecute = true };
		Process.Start(startInfo);
	}

}
