using System;

using Newtonsoft.Json;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class StopRoute : IStopRoute {
		[JsonProperty("operator_name")]
		public string OperatorName { get; set; }

		[JsonProperty("operator_onestop_id")]
		public string OperatorOneStopId { get; set; }

		[JsonProperty("route_name")]
		public string RouteName { get; set; }

		[JsonProperty("route_onestop_id")]
		public string RouteOneStopId { get; set; }
	}
}
