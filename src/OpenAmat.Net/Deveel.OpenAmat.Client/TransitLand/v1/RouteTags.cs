using System;

using Newtonsoft.Json;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class RouteTags {
		[JsonProperty("route_url")]
		public string RouteUrl { get; set; }

		[JsonProperty("route_desc")]
		public string RouteDescription { get; set; }

		[JsonProperty("route_color")]
		public string Color { get; set; }

		[JsonProperty("route_long_name")]
		public string LongName { get; set; }

		[JsonProperty("route_text_color")]
		public string TextColor { get; set; }
	}
}
