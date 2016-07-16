using System;

using Newtonsoft.Json;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class RouteStop : IRouteStop {
		[JsonProperty("stop_onestop_id")]
		public string OneStopId { get; private set; }

		[JsonProperty("stop_name")]
		public string Name { get; private set; }
	}
}
