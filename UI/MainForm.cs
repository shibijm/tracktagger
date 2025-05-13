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

	private readonly List<CustomItem> items = [];
	public string tempDirectory;
	private readonly ListViewColumnSorter listViewColumnSorter = new();

	public MainForm() {
		InitializeComponent();
		tempDirectory = Path.GetTempPath() + "TrackTagger";
		Directory.CreateDirectory(tempDirectory);
	}

	private void MainForm_Load(object sender, EventArgs e) {
		filesListView.ListViewItemSorter = listViewColumnSorter;
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
		folderBrowserDialog1.SelectedPath = Environment.CurrentDirectory;
		DialogResult result = folderBrowserDialog1.ShowDialog();
		if (result == DialogResult.OK) {
			string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.mp3", importSubfoldersCheckBox.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
			ImportFiles(files);
		}
	}

	private void ImportFiles(string[] files) {
		foreach (string filePath in files) {
			if (Directory.Exists(filePath)) {
				ImportFiles(Directory.GetFiles(filePath, "*.mp3", importSubfoldersCheckBox.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
			} else if (Path.GetExtension(filePath) == ".mp3") {
				CustomItem item = new(this, filePath);
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
			if (filesListView.SelectedItems.Count > 0) {
				CustomItem item = (CustomItem) filesListView.SelectedItems[0];
				searchBox.Text = item.searchString;
				if (item.status == 0) {
					searchBox.Enabled = false;
					addCustomResultButton.Enabled = false;
				} else {
					searchBox.Enabled = true;
					addCustomResultButton.Enabled = true;
				}
				if (item.status == 1) {
					searchResultsDropDown.Items.Clear();
					foreach (SearchResult searchResult in item.searchResults) {
						searchResultsDropDown.Items.Add(searchResult.OriginalArtist + " - " + searchResult.OriginalTitle);
					}
					searchResultsDropDown.Enabled = true;
					searchResultsDropDown.SelectedIndex = item.index;
				} else {
					searchResultsDropDown.Items.Clear();
					albumArtPicture.Image = Properties.Resources.DefaultAlbumArt;
					searchResultsDropDown.Enabled = false;
				}
			} else {
				searchBox.Enabled = false;
				searchResultsDropDown.Enabled = false;
				searchBox.Text = "";
				searchResultsDropDown.Items.Clear();
				addCustomResultButton.Enabled = false;
				albumArtPicture.Image = Properties.Resources.DefaultAlbumArt;
			}
		}
	}

	private void SearchBox_KeyDown(object sender, KeyEventArgs e) {
		if (e.KeyCode == Keys.Enter) {
			e.SuppressKeyPress = true;
			foreach (CustomItem item in filesListView.SelectedItems) {
				item.searchString = searchBox.Text;
				if (item.status != 0) {
					item.StartThread();
				}
			}
		}
	}

	private void SearchResultsDropDown_SelectedIndexChanged(object sender, EventArgs e) {
		CustomItem item = (CustomItem) filesListView.SelectedItems[0];
		item.index = searchResultsDropDown.SelectedIndex;
		item.UpdateListViewItem();
		try {
			albumArtPicture.Load(item.searchResults[item.index].AlbumArtFilePath);
		} catch {
			albumArtPicture.Image = Properties.Resources.DefaultAlbumArt;
		}
	}

	private void UnmatchButton_Click(object sender, EventArgs e) {
		dynamic target = filesListView.SelectedItems.Count > 0 ? filesListView.SelectedItems : filesListView.Items;
		foreach (CustomItem item in target) {
			if (item.status == 1) {
				item.SetStatus(-1, "Unmatched");
			}
		}
	}

	private void MatchButton_Click(object sender, EventArgs e) {
		dynamic target = filesListView.SelectedItems.Count > 0 ? filesListView.SelectedItems : filesListView.Items;
		foreach (CustomItem item in target) {
			if (item.status == -1) {
				item.ResetSearchString();
				item.StartThread();
			}
		}
	}

	private void FilesListView_SelectedIndexChanged(object sender, EventArgs e) {
		if (filesListView.SelectedItems.Count > 0) {
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
			foreach (CustomItem item in filesListView.SelectedItems) {
				RemoveItem(item);
			}
		} else if (e.KeyCode == Keys.A && e.Control) {
			foreach (CustomItem item in filesListView.Items) {
				item.Selected = true;
			}
		} else if (e.KeyCode == Keys.Escape) {
			filesListView.SelectedIndices.Clear();
		}
	}

	private void TagButton_Click(object sender, EventArgs e) {
		Enabled = false;
		dynamic target = filesListView.SelectedItems.Count > 0 ? filesListView.SelectedItems : filesListView.Items;
		foreach (CustomItem item in target) {
			TagItem(item);
		}
		Enabled = true;
	}

	private void TagItem(CustomItem item) {
		if (item.status == 1) {
			try {
				DateTime lastWriteTime = File.GetLastWriteTime(item.filePath);
				TagLib.File tagLibFile = TagLib.File.Create(item.filePath);
				if (clearExistingTagsCheckBox.Checked) {
					tagLibFile.RemoveTags(TagLib.TagTypes.AllTags);
					tagLibFile.Save();
					tagLibFile = TagLib.File.Create(item.filePath);
				}
				SearchResult searchResult = item.searchResults[item.index];
				if (albumArtCheckBox.Checked && File.Exists(searchResult.AlbumArtFilePath)) {
					tagLibFile.Tag.Pictures = [new TagLib.Picture(searchResult.AlbumArtFilePath)];
				}
				if (artistCheckBox.Checked) {
					tagLibFile.Tag.Performers = [searchResult.Artist];
				}
				if (titleCheckBox.Checked) {
					tagLibFile.Tag.Title = searchResult.Title;
				}
				if (albumCheckBox.Checked) {
					tagLibFile.Tag.Album = searchResult.Album;
				}
				if (yearCheckBox.Checked) {
					tagLibFile.Tag.Year = searchResult.Year;
				}
				if (genreCheckBox.Checked) {
					tagLibFile.Tag.Genres = [searchResult.Genre];
				}
				if (trackNumberCheckBox.Checked) {
					tagLibFile.Tag.Track = searchResult.Track;
					tagLibFile.Tag.TrackCount = searchResult.TrackCount;
				}
				tagLibFile.RemoveTags(TagLib.TagTypes.AllTags & ~TagLib.TagTypes.Id3v2);
				tagLibFile.Save();
				File.SetLastWriteTime(item.filePath, lastWriteTime);
				if (renameFilesCheckBox.Checked) {
					string newFileName = namingSchemeTextBox.Text.Replace(".mp3", "").Replace("%artist%", searchResult.Artist).Replace("%title%", searchResult.Title).Replace("%album%", searchResult.Album).Replace("%year%", searchResult.Year.ToString()).Replace("%genre%", searchResult.Genre).Replace("%track%", searchResult.Track.ToString().PadLeft(2, '0')).Replace("%trackCount%", searchResult.TrackCount.ToString().PadLeft(2, '0')) + ".mp3";
					newFileName = string.Join("", newFileName.Split(Path.GetInvalidFileNameChars()));
					string newRootFolder = rootFolderTextBox.Text.Replace("%originalFolder%", Path.GetDirectoryName(item.filePath)).Trim().Replace("%artist%", searchResult.Artist).Replace("%title%", searchResult.Title).Replace("%album%", searchResult.Album).Replace("%year%", searchResult.Year.ToString()).Replace("%genre%", searchResult.Genre).Replace("%track%", searchResult.Track.ToString().PadLeft(2, '0')).Replace("%trackCount%", searchResult.TrackCount.ToString().PadLeft(2, '0'));
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

	private void RemoveItem(CustomItem item) {
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
		filesListView.Sort();
	}

	private void AddCustomResultButton_Click(object sender, EventArgs e) {
		MessageBox.Show("TBD");
		new CustomResultForm(this).ShowDialog();
	}

	public void CustomResultCallback(SearchResult searchResult) {
		foreach (CustomItem item in filesListView.SelectedItems) {
			if (item.status != 0) {
				item.searchResults.Add(searchResult);
				item.index = item.searchResults.Count - 1;
				item.SetStatus(1, "Matched");
			}
		}
	}

	private void AlbumArtPicture_DoubleClick(object sender, EventArgs e) {
		if (filesListView.SelectedItems.Count > 0) {
			CustomItem item = (CustomItem) filesListView.SelectedItems[0];
			Process.Start(item.searchResults[item.index].AlbumArtFilePath);
		}
	}

}
