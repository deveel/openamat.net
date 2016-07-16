using System;

using Newtonsoft.Json;

namespace Deveel.OpenAmat {
	public sealed class StopRoute {
		[JsonProperty("operator_name")]
		public string OperatorName { get; set; }

		[JsonProperty("operator_onestop_id")]
		public string OperatorId { get; set; }

		[JsonProperty("route_name")]
		public string RouteName { get; set; }

		[JsonProperty("route_onestop_id")]
		public string RouteId { get; set; }
	}
}
