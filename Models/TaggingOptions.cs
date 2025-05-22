namespace TrackTagger.Models;

public class TaggingOptions {

	public bool ClearExistingTags { get; set; }
	public bool UpdateAlbumArt { get; set; }
	public bool UpdateArtist { get; set; }
	public bool UpdateTitle { get; set; }
	public bool UpdateAlbum { get; set; }
	public bool UpdateYear { get; set; }
	public bool UpdateGenre { get; set; }
	public bool UpdateTrackNumber { get; set; }
	public bool UpdateDiscNumber { get; set; }
	public bool RenameFiles { get; set; }
	public string BasePathTemplate { get; set; }
	public string FileNameTemplate { get; set; }

}
