using System;

using Newtonsoft.Json;

namespace Deveel.OpenAmat {
	public sealed class StopOperator {
		[JsonProperty("operator_name")]
		public string Name { get; set; }

		[JsonProperty("operator_onestop_id")]
		public string Id { get; set; }
	}
}
