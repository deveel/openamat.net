using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Deveel.OpenAmat {
	public sealed class StopGeometry {
		[JsonProperty("type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public GeometryType Type { get; set; }

		[JsonProperty("coordinates")]
		public double[] Coordinates { get; set; }
	}
}
