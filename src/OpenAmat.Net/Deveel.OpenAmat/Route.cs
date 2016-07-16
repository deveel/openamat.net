using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Deveel.OpenAmat {
	public class Route {
		[JsonProperty("name")]
		public string Name { get; private set; }

		[JsonProperty("geometry")]
		public RouteGeometry Geometry { get; private set; }

		[JsonProperty("vehicle_type")]
		public string VeihcleType { get; private set; }

		[JsonProperty("stops_served_by_route")]
		public List<RouteStop> Stops { get; private set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; private set; }

		[JsonProperty("updated_at")]
		public DateTime UpdatedAt { get; private set; }
	}
}
