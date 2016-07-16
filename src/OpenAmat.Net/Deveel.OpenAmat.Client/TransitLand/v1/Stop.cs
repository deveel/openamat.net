using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class Stop : IStop {
		[JsonProperty("name")]
		public string Name { get; private set; }

		[JsonProperty("onestop_id")]
		public string OneStopId { get; private set; }

		[JsonProperty("tags")]
		public StopTags Tags { get; private set; }

		IList<string> IStop.Identifiers {
			get { return Identifiers; }
		}

		[JsonProperty("identifiers")]
		public List<string> Identifiers { get; set; }

		[JsonProperty("geometry")]
		public StopGeometry Geometry { get; private set; }

		public IList<IStopFeature> Features {
			get { return FormFeatures(); }
		}

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

		private IList<IStopFeature> FormFeatures() {
			var list = new List<IStopFeature>();

			if (Tags != null) {
				if (!String.IsNullOrEmpty(Tags.ZoneId)) {
					list.Add(new StopFeature(StopFeatureType.ZoneId, Tags.ZoneId));
				}
				if (!String.IsNullOrEmpty(Tags.WheelChairBoarding)) {
					var value = String.Equals("1", Tags.WheelChairBoarding);
					list.Add(new StopFeature(StopFeatureType.WheelChairBoarding, value));
				}
				if (!String.IsNullOrEmpty(Tags.OsmWayId))
					list.Add(new StopFeature(StopFeatureType.OsmWayId, Tags.OsmWayId));
				if (!String.IsNullOrEmpty(Tags.StopUrl))
					list.Add(new StopFeature(StopFeatureType.Url, Tags.StopUrl));
				if (!String.IsNullOrEmpty(Tags.StopDescription))
					list.Add(new StopFeature(StopFeatureType.Description, Tags.StopDescription));
			}

			return list;
		}
	}
}
