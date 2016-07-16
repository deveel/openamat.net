using System;

using Newtonsoft.Json;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class StopTags {
		[JsonProperty("wheelchair_boarding")]
		public string WheelChairBoarding { get; set; }

		[JsonProperty("stop_url")]
		public string StopUrl { get; set; }

		[JsonProperty("stop_desc")]
		public string StopDescription { get; set; }

		[JsonProperty("zone_id")]
		public string ZoneId { get; set; }

		[JsonProperty("osm_way_id")]
		public string OsmWayId { get; set; }
	}
}
