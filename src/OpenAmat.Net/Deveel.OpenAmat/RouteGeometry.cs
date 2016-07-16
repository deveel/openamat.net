using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Deveel.OpenAmat {
	public sealed class RouteGeometry {
		[JsonProperty("type")]
		public GeometryType Type { get; private set; }

		[JsonProperty("coordinates")]
		public List<List<double[]>> Coordinates { get; private set; }
	}
}
