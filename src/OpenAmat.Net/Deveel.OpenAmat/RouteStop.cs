using System;

using Newtonsoft.Json;

namespace Deveel.OpenAmat {
	public sealed class RouteStop {
		[JsonProperty("stop_onestop_id")]
		public string Id { get; private set; }

		[JsonProperty("stop_name")]
		public string Name { get; private set; }
	}
}
