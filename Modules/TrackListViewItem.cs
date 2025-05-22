using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TrackTagger.Models;

namespace TrackTagger.Modules;

public partial class TrackListViewItem : ListViewItem {

	public event EventHandler StatusChanged;

	public string FilePath { get; }
	public List<Track> Tracks { get; } = [];
	public int SelectedTrackIndex { get; private set; }
	public string Query {
		get => _query ?? $"{FilterTag(originalTrack.Artist)} {FilterTag(originalTrack.Title)}".Trim();
		private set => _query = value;
	}
	public int Status { get; private set; }
	public Track SelectedTrack => Status == 1 ? Tracks[SelectedTrackIndex] : originalTrack;

	private const int fileNameSubItemIndex = 0;
	private const int statusSubItemIndex = 8;
	private const int filePathSubItemIndex = 9;
	private const int otherSubItemsStartIndex = 1;
	private readonly Track originalTrack = new();
	private string _query;

	public TrackListViewItem(string filePath, int columnCount) : base(new string[columnCount]) {
		FilePath = filePath;
		SubItems[filePathSubItemIndex].Text = filePath;
		string fileName = Path.GetFileNameWithoutExtension(filePath);
		SubItems[fileNameSubItemIndex].Text = fileName;
		string[] fileNameSplit = fileName.Split(" - ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
		using TagLib.File tagLibFile = TagLib.File.Create(filePath);
		originalTrack.Artist = tagLibFile.Tag.FirstPerformer ?? fileNameSplit[0];
		originalTrack.Title = tagLibFile.Tag.Title ?? (
			fileNameSplit.Length > 1
				? fileNameSplit[1]
				: string.IsNullOrEmpty(tagLibFile.Tag.FirstPerformer) ? "" : fileName.Trim()
		);
		originalTrack.Album = tagLibFile.Tag.Album ?? "";
		originalTrack.Year = tagLibFile.Tag.Year;
		originalTrack.Genre = tagLibFile.Tag.FirstGenre ?? "";
		originalTrack.TrackNumber = tagLibFile.Tag.Track;
		originalTrack.TrackCount = tagLibFile.Tag.TrackCount;
		originalTrack.DiscNumber = tagLibFile.Tag.Disc;
		originalTrack.DiscCount = tagLibFile.Tag.DiscCount;
		originalTrack.DurationMs = (uint) tagLibFile.Properties.Duration.TotalMilliseconds;
		SetStatus(-1, "Unmatched");
	}

	private static string FilterTag(string tag) {
		tag = tag.Split(["&", ",", "(with", "(feat"], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).FirstOrDefault("");
		tag = TrackNumberRegex().Replace(tag, "");
		return tag;
	}

	private void SetStatus(int status, string statusString) {
		Status = status;
		if (status != 1) {
			SelectedTrackIndex = -1;
			Tracks.Clear();
		}
		SubItems[statusSubItemIndex].Text = statusString;
		UpdateSubItems();
		StatusChanged?.Invoke(this, EventArgs.Empty);
	}

	public void Match(string query = null) {
		if (Status == 0) {
			return;
		}
		if (query != null) {
			Query = query;
		}
		SetStatus(0, "Fetching");
		Search();
	}

	public void Unmatch() {
		if (Status != 0) {
			SetStatus(-1, "Unmatched");
		}
	}

	public void SetSelectedTrackIndex(int index) {
		SelectedTrackIndex = index;
		UpdateSubItems();
	}

	private void UpdateSubItems() {
		int i = otherSubItemsStartIndex;
		SubItems[i++].Text = SelectedTrack.Artist;
		SubItems[i++].Text = SelectedTrack.Title;
		SubItems[i++].Text = SelectedTrack.Album;
		SubItems[i++].Text = SelectedTrack.Year.ToString();
		SubItems[i++].Text = SelectedTrack.Genre;
		SubItems[i++].Text = $"{SelectedTrack.TrackNumber}/{SelectedTrack.TrackCount}";
		SubItems[i++].Text = $"{SelectedTrack.DiscNumber}/{SelectedTrack.DiscCount}";
	}

	private async void Search() {
		using HttpClient httpClient = new();
		string response = "";
		try {
			response = await httpClient.GetStringAsync($"https://itunes.apple.com/search?media=music&entity=song&term={Query}");
		} catch (Exception e) {
			SetStatus(-1, $"Error: {e.Message}");
			return;
		}
		ITunesSearchResponse data = JsonSerializer.Deserialize<ITunesSearchResponse>(response);
		IEnumerable<ITunesItem> items = data.Results.Where(item => item.WrapperType == "track");
		if (!items.Any()) {
			SetStatus(-1, "No results");
			return;
		}
		foreach (ITunesItem item in items) {
			Track track = new() {
				OriginalArtist = item.ArtistName,
				OriginalTitle = item.TrackName,
				Title = item.TrackName,
				Album = item.CollectionName,
				Year = (uint) item.ReleaseDate.Year,
				Genre = item.PrimaryGenreName,
				TrackNumber = item.TrackNumber,
				TrackCount = item.TrackCount,
				DiscNumber = item.DiscNumber,
				DiscCount = item.DiscCount,
				DurationMs = item.TrackTimeMillis,
				AlbumArtFilePath = Path.Join(Program.TempDirectory, $"{item.CollectionId}.jpg")
			};
			string[] artistNames = item.ArtistName.Split(['&', ','], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
			track.Artist = artistNames.ElementAt(0);
			if (artistNames.Length > 1) {
				string withArtists = artistNames.Length > 2
					? $"{string.Join(", ", artistNames.Skip(1).SkipLast(1))} & {artistNames.Last()}"
					: string.Join(", ", artistNames.Skip(1));
				track.Title += $" (with {withArtists})";
			}
			if (!File.Exists(track.AlbumArtFilePath)) {
				try {
					using Stream stream = await httpClient.GetStreamAsync(item.ArtworkUrl100.Replace("100x100", "1000x1000"));
					using FileStream fileStream = File.Create(track.AlbumArtFilePath);
					stream.CopyTo(fileStream);
				} catch (Exception e) {
					SetStatus(-1, $"Error: {e.Message}");
					return;
				}
			}
			Tracks.Add(track);
		}
		int index = 0;
		bool perfectMatch = false;
		for (int i = 0; i < Tracks.Count; i++) {
			Track track = Tracks[i];
			if (
				track.Artist == originalTrack.Artist
				&& track.Title == originalTrack.Title
				&& (track.Album == originalTrack.Album || string.IsNullOrEmpty(originalTrack.Album))
			) {
				index = i;
				perfectMatch = true;
				break;
			}
		}
		if (!perfectMatch) {
			int closestDifference = int.MaxValue;
			for (int i = Tracks.Count - 1; i > -1; i--) {
				Track track = Tracks[i];
				int difference = Math.Abs((int) track.DurationMs - (int) originalTrack.DurationMs);
				if (difference - 3000 <= closestDifference) {
					closestDifference = difference;
					index = i;
				}
			}
		}
		SelectedTrackIndex = index;
		SetStatus(1, "Matched");
	}

	public bool TagFile(TaggingOptions options) {
		if (Status != 1) {
			return false;
		}
		try {
			DateTime lastWriteTime = File.GetLastWriteTime(FilePath);
			TagLib.File tagLibFile = TagLib.File.Create(FilePath);
			if (options.ClearExistingTags) {
				tagLibFile.RemoveTags(TagLib.TagTypes.AllTags);
				tagLibFile.Save();
				tagLibFile.Dispose();
				tagLibFile = TagLib.File.Create(FilePath);
			}
			if (options.UpdateAlbumArt && File.Exists(SelectedTrack.AlbumArtFilePath)) {
				tagLibFile.Tag.Pictures = [new TagLib.Picture(SelectedTrack.AlbumArtFilePath)];
			}
			if (options.UpdateArtist) {
				tagLibFile.Tag.Performers = [SelectedTrack.Artist];
			}
			if (options.UpdateTitle) {
				tagLibFile.Tag.Title = SelectedTrack.Title;
			}
			if (options.UpdateAlbum) {
				tagLibFile.Tag.Album = SelectedTrack.Album;
			}
			if (options.UpdateYear) {
				tagLibFile.Tag.Year = SelectedTrack.Year;
			}
			if (options.UpdateGenre) {
				tagLibFile.Tag.Genres = [SelectedTrack.Genre];
			}
			if (options.UpdateTrackNumber) {
				tagLibFile.Tag.Track = SelectedTrack.TrackNumber;
				tagLibFile.Tag.TrackCount = SelectedTrack.TrackCount;
			}
			if (options.UpdateDiscNumber) {
				tagLibFile.Tag.Disc = SelectedTrack.DiscNumber;
				tagLibFile.Tag.DiscCount = SelectedTrack.DiscCount;
			}
			tagLibFile.RemoveTags(TagLib.TagTypes.Id3v1);
			tagLibFile.Save();
			tagLibFile.Dispose();
			File.SetLastWriteTime(FilePath, lastWriteTime);
			if (options.RenameFiles) {
				string newBasePath = SanitiseFileName(SelectedTrack.PopulateTemplate(options.BasePathTemplate)).Replace("%originalFolder%", Path.GetDirectoryName(FilePath));
				if (!Directory.Exists(newBasePath)) {
					Directory.CreateDirectory(newBasePath);
				}
				string newFileName = SanitiseFileName(SelectedTrack.PopulateTemplate(options.FileNameTemplate));
				string newFilePath = Path.Join(newBasePath, $"{newFileName}{Path.GetExtension(FilePath)}");
				if (newFilePath != FilePath) {
					File.Move(FilePath, newFilePath);
				}
			}
			return true;
		} catch (Exception e) {
			SetStatus(-1, $"Error: {e.Message}");
			return false;
		}
	}

	private static string SanitiseFileName(string fileName) {
		return string.Concat(fileName.Split(Path.GetInvalidFileNameChars()));
	}

	[GeneratedRegex(@"\d+\. ")]
	private static partial Regex TrackNumberRegex();

}
