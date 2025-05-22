using System.Collections.Generic;

namespace TrackTagger.Models;

public class Track {

	public string OriginalArtist { get; set; }
	public string OriginalTitle { get; set; }
	public string Artist { get; set; }
	public string Title { get; set; }
	public string Album { get; set; }
	public uint Year { get; set; }
	public string Genre { get; set; }
	public uint TrackNumber { get; set; }
	public uint TrackCount { get; set; }
	public uint DiscNumber { get; set; }
	public uint DiscCount { get; set; }
	public uint DurationMs { get; set; }
	public string AlbumArtFilePath { get; set; }

	public string PopulateTemplate(string template) {
		Dictionary<string, string> replacements = new() {
			{ "%artist%", Artist },
			{ "%title%", Title },
			{ "%album%", Album },
			{ "%year%", Year.ToString() },
			{ "%genre%", Genre },
			{ "%trackNumber%", TrackNumber.ToString().PadLeft(2, '0') },
			{ "%trackCount%", TrackCount.ToString().PadLeft(2, '0') },
			{ "%discNumber%", DiscNumber.ToString().PadLeft(2, '0') },
			{ "%discCount%", DiscCount.ToString().PadLeft(2, '0') },
		};
		foreach (KeyValuePair<string, string> kvp in replacements) {
			template = template.Replace(kvp.Key, kvp.Value);
		}
		return template;
	}

}
