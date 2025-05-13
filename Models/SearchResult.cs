namespace TrackTagger.Models;

public class SearchResult {

	public uint ArtistID { get; set; }
	public string Artist { get; set; }
	public string OriginalArtist { get; set; }
	public uint TrackID { get; set; }
	public string Title { get; set; }
	public string OriginalTitle { get; set; }
	public uint AlbumID { get; set; }
	public string Album { get; set; }
	public uint Year { get; set; }
	public string Genre { get; set; }
	public uint Track { get; set; }
	public uint TrackCount { get; set; }
	public string AlbumArtURL { get; set; }
	public string AlbumArtFilePath { get; set; }

}
