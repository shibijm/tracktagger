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

	public string FilePath { get; }
	public List<Track> Tracks { get; } = [];
	public int SelectedTrackIndex { get; set; } = 0;
	public string Query { get; set; }
	public int Status { get; private set; } = 0;

	private readonly MainForm mainForm;
	private readonly string filename;
	private readonly Track originalTrack = new();

	public TrackListViewItem(MainForm mainForm, string filePath) : base([Path.GetFileNameWithoutExtension(filePath), "", "", "", "", "", "", "", "Reading", filePath]) {
		this.mainForm = mainForm;
		FilePath = filePath;
		filename = Path.GetFileNameWithoutExtension(filePath);
		using TagLib.File tagLibFile = TagLib.File.Create(filePath);
		string[] filenameSplit = filename.Split([" - "], StringSplitOptions.None);
		bool usedTagArtist = false;
		if (string.IsNullOrEmpty(tagLibFile.Tag.FirstPerformer)) {
			originalTrack.Artist = filenameSplit[0].Trim();
		} else {
			originalTrack.Artist = tagLibFile.Tag.FirstPerformer;
			usedTagArtist = true;
		}
		if (string.IsNullOrEmpty(tagLibFile.Tag.Title)) {
			if (filenameSplit.Length > 1) {
				originalTrack.Title = filenameSplit[1].Trim();
			} else if (usedTagArtist) {
				originalTrack.Title = filename.Trim();
			}
		} else {
			originalTrack.Title = tagLibFile.Tag.Title;
		}
		originalTrack.Album = string.IsNullOrEmpty(tagLibFile.Tag.Album) ? "" : tagLibFile.Tag.Album;
		originalTrack.Year = tagLibFile.Tag.Year;
		originalTrack.Genre = string.IsNullOrEmpty(tagLibFile.Tag.FirstGenre) ? "" : tagLibFile.Tag.FirstGenre;
		originalTrack.TrackNumber = tagLibFile.Tag.Track;
		originalTrack.TrackCount = tagLibFile.Tag.TrackCount;
		originalTrack.DiscNumber = tagLibFile.Tag.Disc;
		originalTrack.DiscCount = tagLibFile.Tag.DiscCount;
		ResetSearchString();
	}

	public void ResetSearchString() {
		Query = (originalTrack.Artist.Split('&')[0].Split(',')[0].Trim() + " " + originalTrack.Title.Split(["(with"], StringSplitOptions.None)[0].Split(["(feat"], StringSplitOptions.None)[0].Trim()).Trim();
		Query = Regex.Replace(Query, "[^ ]+\\.[A-za-z]+", "");
	}

	public void SetStatus(int status, string statusString) {
		if (mainForm.InvokeRequired) {
			mainForm.Invoke(new Action(() => SetStatus(status, statusString)));
		} else {
			Status = status;
			if (status != 1) {
				SelectedTrackIndex = 0;
				Tracks.Clear();
			}
			if (Selected) {
				mainForm.UpdateSearchControls();
			}
			SubItems[8].Text = statusString;
			UpdateSubItems();
		}
	}

	public void UpdateSubItems() {
		Track track = Status == 1 ? Tracks[SelectedTrackIndex] : originalTrack;
		SubItems[1].Text = track.Artist;
		SubItems[2].Text = track.Title;
		SubItems[3].Text = track.Album;
		SubItems[4].Text = track.Year.ToString();
		SubItems[5].Text = track.Genre;
		SubItems[6].Text = $"{track.TrackNumber}/{track.TrackCount}";
		SubItems[7].Text = $"{track.DiscNumber}/{track.DiscCount}";
	}

	public void StartSearchThread() {
		SetStatus(0, "Waiting");
		new Thread(Search).Start();
	}

	private void Search() {
		string url = $"https://itunes.apple.com/search?media=music&entity=song&term={Query}";
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
				DiscNumber = item.DiscNumber,
				DiscCount = item.DiscCount,
				AlbumArtFilePath = Path.Join(Program.TempDirectory, $"{item.CollectionId}.jpg")
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
			Tracks.Add(track);
		}
		SetStatus(1, "Matched");
	}

}
