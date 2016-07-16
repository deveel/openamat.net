using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Deveel.OpenAmat {
	public sealed class Stop {
		[JsonProperty("name")]
		public string Name { get; private set; }

		[JsonProperty("onestop_id")]
		public string Id { get; private set; }

		[JsonProperty("geometry")]
		public StopGeometry Geometry { get; private set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; private set; }

		[JsonProperty("updated_at")]
		public DateTime UpdatedAt { get; private set; }

		[JsonProperty("operators_serving_stop")]
		public List<StopOperator> Operators { get; private set; }

		[JsonProperty("routes_serving_stop")]
		public List<StopRoute> Routes { get; private set; }
	}
}
