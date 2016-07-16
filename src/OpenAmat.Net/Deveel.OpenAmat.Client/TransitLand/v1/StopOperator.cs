using System;

using Newtonsoft.Json;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class StopOperator : IStopOperator {
		[JsonProperty("operator_name")]
		public string Name { get; set; }

		[JsonProperty("operator_onestop_id")]
		public string Id { get; set; }
	}
}
