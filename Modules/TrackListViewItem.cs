using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using TrackTagger.Models;
using TrackTagger.UI;

namespace TrackTagger.Modules;

public class TrackListViewItem : ListViewItem {

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
	public List<Track> tracks = [];
	public int status = 0;
	public int index = 0;

	public TrackListViewItem(MainForm mainForm, string filePath) : base([Path.GetFileNameWithoutExtension(filePath), "", "", "", "", "", "", "Reading", filePath]) {
		this.mainForm = mainForm;
		this.filePath = filePath;
		filename = Path.GetFileNameWithoutExtension(filePath);
		using TagLib.File tagLibFile = TagLib.File.Create(filePath);
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
		ResetSearchString();
	}

	public void ResetSearchString() {
		searchString = (artist.Split('&')[0].Split(',')[0].Trim() + " " + title.Split(["(with"], StringSplitOptions.None)[0].Split(["(feat"], StringSplitOptions.None)[0].Trim()).Trim();
		searchString = Regex.Replace(searchString, "[^ ]+\\.[A-za-z]+", "");
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
				tracks.Clear();
			}
			if (Selected) {
				mainForm.UpdateSearchControls();
			}
			SubItems[7].Text = statusString;
			UpdateListViewItem();
		}
	}

	public void UpdateListViewItem() {
		SubItems[1].Text = status == 1 ? tracks[index].Artist : artist;
		SubItems[2].Text = status == 1 ? tracks[index].Title : title;
		SubItems[3].Text = status == 1 ? tracks[index].Album : album;
		SubItems[4].Text = status == 1 ? tracks[index].Year.ToString() : year.ToString();
		SubItems[5].Text = status == 1 ? tracks[index].Genre : genre;
		SubItems[6].Text = status == 1 ? tracks[index].TrackNumber + "/" + tracks[index].TrackCount : track + "/" + trackCount;
	}

	private void GetTags() {
		string url = $"https://itunes.apple.com/search?media=music&entity=song&term={searchString}";
		using HttpClient httpClient = new();
		string response = "";
		int tries = 0;
		int retryLimit = 5;
		while (response == "" && tries < retryLimit) {
			try {
				response = httpClient.GetStringAsync(url).Result;
			} catch {
				if (tries < retryLimit) {
					Thread.Sleep(5000);
				}
			}
			tries++;
		}
		if (response == "") {
			SetStatus(-1, "Failed");
			return;
		}
		ITunesSearchResponse data = JsonSerializer.Deserialize<ITunesSearchResponse>(response);
		if (data.ResultCount == 0) {
			SetStatus(-1, "No results");
			return;
		}
		foreach (ITunesItem item in data.Results) {
			if (item.WrapperType != "track") {
				continue;
			}
			Track track = new() {
				OriginalTitle = item.TrackName,
				OriginalArtist = item.ArtistName,
				Album = item.CollectionName,
				Year = (uint) item.ReleaseDate.Year,
				Genre = item.PrimaryGenreName,
				TrackNumber = item.TrackNumber,
				TrackCount = item.TrackCount,
				AlbumArtFilePath = mainForm.tempDirectory + "\\" + item.CollectionId + ".jpg"
			};
			if (!string.IsNullOrEmpty(item.TrackCensoredName) && item.TrackCensoredName.StartsWith(item.TrackName)) {
				track.OriginalTitle = item.TrackCensoredName;
			}
			string[] artistSplit = item.ArtistName.Split('&');
			List<string> artistSplit2 = [.. artistSplit[0].Split(',')];
			track.Artist = artistSplit2[0].Trim();
			artistSplit2.RemoveAt(0);
			artistSplit2 = [.. artistSplit2.Select(x => x.Trim())];
			track.Title = artistSplit.Length > 1
				? artistSplit2.Count > 0
					? track.OriginalTitle + " (with " + string.Join(", ", artistSplit2) + " & " + artistSplit[1].Trim() + ")"
					: track.OriginalTitle + " (with " + artistSplit[1].Trim() + ")"
				: artistSplit2.Count > 0
					? track.OriginalTitle + " (with " + artistSplit2[0] + ")"
					: track.OriginalTitle;
			if (!File.Exists(track.AlbumArtFilePath)) {
				try {
					WebClient webClient = new();
					webClient.DownloadFile(item.ArtworkUrl100.Replace("100x100", "1000x1000"), track.AlbumArtFilePath);
				} catch { }
			}
			tracks.Add(track);
		}
		SetStatus(1, "Matched");
	}

}
