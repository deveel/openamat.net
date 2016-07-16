using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class Stop : IStop {
		[JsonProperty("name")]
		public string Name { get; private set; }

		[JsonProperty("onestop_id")]
		public string Id { get; private set; }

		[JsonProperty("geometry")]
		public StopGeometry Geometry { get; private set; }

		IStopGeometry IStop.Geometry {
			get { return Geometry; }
		}

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; private set; }

		[JsonProperty("updated_at")]
		public DateTime UpdatedAt { get; private set; }

		[JsonProperty("operators_serving_stop")]
		public List<StopOperator> Operators { get; private set; }

		IList<IStopOperator> IStop.Operators {
			get { return Operators.Cast<IStopOperator>().ToList(); }
		}

		[JsonProperty("routes_serving_stop")]
		public List<StopRoute> Routes { get; private set; }

		IList<IStopRoute> IStop.Routes {
			get { return Routes.Cast<IStopRoute>().ToList(); }
		}
	}
}
