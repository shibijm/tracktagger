using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using TrackTagger.Models;
using TrackTagger.UI;

namespace TrackTagger.Modules;

public partial class CustomItem : ListViewItem {

	private readonly MainForm mainForm;
	public string filePath;
	public string filename;
	public string artist = "";
	public string title = "";
	public string album = "";
	public uint year = 0;
	public string genre = "";
	public uint track = 0;
	public uint trackCount = 0;
	private Thread httpThread;
	public string searchString;
	public List<SearchResult> searchResults = [];
	public int status = 0;
	public int index = 0;

	public CustomItem(MainForm mainForm, string filePath) : base([Path.GetFileNameWithoutExtension(filePath), "", "", "", "", "", "", "Reading", filePath]) {
		this.mainForm = mainForm;
		this.filePath = filePath;
		filename = Path.GetFileNameWithoutExtension(filePath);
		mainForm.filesListView.Items.Add(this);
		TagLib.File tagLibFile = TagLib.File.Create(filePath);
		string[] filenameSplit = filename.Split([" - "], StringSplitOptions.None);
		bool usedTagArtist = false;
		if (string.IsNullOrEmpty(tagLibFile.Tag.FirstPerformer)) {
			artist = filenameSplit[0].Trim();
		} else {
			artist = tagLibFile.Tag.FirstPerformer;
			usedTagArtist = true;
		}
		if (string.IsNullOrEmpty(tagLibFile.Tag.Title)) {
			if (filenameSplit.Length > 1) {
				title = filenameSplit[1].Trim();
			} else if (usedTagArtist) {
				title = filename.Trim();
			}
		} else {
			title = tagLibFile.Tag.Title;
		}
		album = string.IsNullOrEmpty(tagLibFile.Tag.Album) ? "" : tagLibFile.Tag.Album;
		year = tagLibFile.Tag.Year;
		genre = string.IsNullOrEmpty(tagLibFile.Tag.FirstGenre) ? "" : tagLibFile.Tag.FirstGenre;
		track = tagLibFile.Tag.Track;
		trackCount = tagLibFile.Tag.TrackCount;
		tagLibFile.Dispose();
		ResetSearchString();
	}

	public void ResetSearchString() {
		searchString = (artist.Split('&')[0].Split(',')[0].Trim() + " " + title.Split(["(with"], StringSplitOptions.None)[0].Split(["(feat"], StringSplitOptions.None)[0].Trim()).Trim();
		searchString = MyRegex().Replace(searchString, "");
	}

	public void StartThread() {
		SetStatus(0, "Waiting");
		httpThread = new Thread(() => GetTags());
		httpThread.Start();
	}

	public void SetStatus(int status, string statusString) {
		if (mainForm.InvokeRequired) {
			mainForm.Invoke(new Action(() => SetStatus(status, statusString)));
		} else {
			this.status = status;
			if (status != 1) {
				index = 0;
				searchResults.Clear();
			}
			if (Selected) {
				mainForm.UpdateSearchControls();
			}
			SubItems[7].Text = statusString;
			UpdateListViewItem();
		}
	}

	public void UpdateListViewItem() {
		SubItems[1].Text = status == 1 ? searchResults[index].Artist : artist;
		SubItems[2].Text = status == 1 ? searchResults[index].Title : title;
		SubItems[3].Text = status == 1 ? searchResults[index].Album : album;
		SubItems[4].Text = status == 1 ? searchResults[index].Year.ToString() : year.ToString();
		SubItems[5].Text = status == 1 ? searchResults[index].Genre : genre;
		SubItems[6].Text = status == 1 ? searchResults[index].Track + "/" + searchResults[index].TrackCount : track + "/" + trackCount;
	}

	private void GetTags() {
		string response = null;
		string url = "https://itunes.apple.com/search?entity=song&term=" + searchString;
		int tries = 0;
		int retryLimit = 5;
		while (response == null && tries < retryLimit) {
			try {
				WebClient webClient = new() {
					CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore),
					Encoding = System.Text.Encoding.UTF8
				};
				response = webClient.DownloadString(url);
			} catch {
				if (tries < retryLimit) {
					Thread.Sleep(5000);
				}
			}
			tries++;
		}
		if (response == null) {
			SetStatus(-1, "Failed");
			return;
		}
		JsonNode data = JsonNode.Parse(response);
		if ((int) data["resultCount"] == 0) {
			SetStatus(-1, "No results");
			return;
		}
		foreach (JsonNode result in data["results"].AsArray()) {
			if ((string) result["wrapperType"] != "track") {
				continue;
			}
			SearchResult searchResult = new() {
				ArtistID = (uint) result["artistId"],
				OriginalTitle = (string) result["trackName"]
			};
			string altTitle = (string) result["trackCensoredName"];
			if (!string.IsNullOrEmpty(altTitle) && altTitle.StartsWith(searchResult.OriginalTitle)) {
				searchResult.OriginalTitle = altTitle;
			}
			searchResult.TrackID = (uint) result["trackId"];
			searchResult.OriginalArtist = (string) result["artistName"];
			searchResult.AlbumID = (uint) result["collectionId"];
			searchResult.Album = (string) result["collectionName"];
			Console.WriteLine(response);
			try {
				searchResult.Year = uint.Parse(((string) result["releaseDate"]).Substring(6, 4));
			} catch {
				searchResult.Year = (uint) DateTime.Now.Year;
			}
			searchResult.Genre = (string) result["primaryGenreName"];
			searchResult.Track = (uint) result["trackNumber"];
			searchResult.TrackCount = (uint) result["trackCount"];
			searchResult.AlbumArtURL = (string) result["artworkUrl100"];
			searchResult.AlbumArtURL = searchResult.AlbumArtURL.Replace("100x100", "1000x1000");
			searchResult.AlbumArtFilePath = mainForm.tempDirectory + "\\" + searchResult.AlbumID + ".jpg";
			string[] artistSplit = searchResult.OriginalArtist.Split('&');
			List<string> artistSplit2 = [.. artistSplit[0].Split(',')];
			searchResult.Artist = artistSplit2[0].Trim();
			artistSplit2.RemoveAt(0);
			artistSplit2 = [.. artistSplit2.Select(x => x.Trim())];
			searchResult.Title = artistSplit.Length > 1
				? artistSplit2.Count > 0
					? searchResult.OriginalTitle + " (with " + string.Join(", ", artistSplit2) + " & " + artistSplit[1].Trim() + ")"
					: searchResult.OriginalTitle + " (with " + artistSplit[1].Trim() + ")"
				: artistSplit2.Count > 0
					? searchResult.OriginalTitle + " (with " + artistSplit2[0] + ")"
					: searchResult.OriginalTitle;
			if (!File.Exists(searchResult.AlbumArtFilePath)) {
				try {
					WebClient webClient = new();
					webClient.DownloadFile(searchResult.AlbumArtURL, searchResult.AlbumArtFilePath);
				} catch { }
			}
			searchResults.Add(searchResult);
		}
		SetStatus(1, "Matched");
	}

	[GeneratedRegex("[^ ]+\\.[A-za-z]+")]
	private static partial Regex MyRegex();
}
