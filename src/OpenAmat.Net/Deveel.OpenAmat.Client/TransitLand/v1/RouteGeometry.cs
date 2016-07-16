using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Deveel.OpenAmat {
	class RouteGeometry : IRouteGeometry {
		[JsonProperty("type")]
		public GeometryType Type { get; private set; }

		[JsonProperty("coordinates")]
		public List<List<double[]>> Coordinates { get; private set; }

		IList<IList<double[]>> IRouteGeometry.Coordinates {
			get { return new List<IList<double[]>>(Coordinates); }
		}
	}
}
