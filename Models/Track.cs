namespace TrackTagger.Models;

public class Track {

	public string Artist { get; set; }
	public string OriginalArtist { get; set; }
	public string Title { get; set; }
	public string OriginalTitle { get; set; }
	public string Album { get; set; }
	public uint Year { get; set; }
	public string Genre { get; set; }
	public uint TrackNumber { get; set; }
	public uint TrackCount { get; set; }
	public string AlbumArtFilePath { get; set; }

}
