using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrackTagger.Models;

public class ITunesSearchResponse {

	[JsonPropertyName("resultCount")]
	public int ResultCount { get; set; }

	[JsonPropertyName("results")]
	public List<ITunesItem> Results { get; set; }

}
