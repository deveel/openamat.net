using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class StopGeometry : IStopGeometry {
		[JsonProperty("type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public GeometryType Type { get; set; }

		[JsonProperty("coordinates")]
		public double[] Coordinates { get; set; }
	}
}
