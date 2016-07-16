using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	 class Route : IRoute {
		[JsonProperty("name")]
		public string Name { get; private set; }

		[JsonProperty("onestop_id")]
		public string OneStopId { get; set; }

		public List<string> Identifiers { get; set; }

		 IList<string> IRoute.Identifiers {
			 get { return Identifiers; }
		 }

		[JsonProperty("geometry")]
		public RouteGeometry Geometry { get; private set; }

		[JsonProperty("vehicle_type")]
		public string VeihcleType { get; private set; }

		[JsonProperty("tags")]
		public RouteTags Tags { get; set; }

		 public IList<IRouteFeature> Features {
			 get { return FormFeatures(); }
		 }

		[JsonProperty("stops_served_by_route")]
		public List<RouteStop> Stops { get; private set; }

		IList<IRouteStop> IRoute.Stops {
			get { return Stops.Cast<IRouteStop>().ToList(); }
		}

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; private set; }

		[JsonProperty("updated_at")]
		public DateTime UpdatedAt { get; private set; }

		 private IList<IRouteFeature> FormFeatures() {
			 var list = new List<IRouteFeature>();

			 if (Tags != null) {
				if (!String.IsNullOrEmpty(Tags.LongName))
					list.Add(new RouteFeature(RouteFeatureType.LongName, Tags.LongName));
				if (!String.IsNullOrEmpty(Tags.RouteUrl))
					list.Add(new RouteFeature(RouteFeatureType.Url, Tags.RouteUrl));
				if (!String.IsNullOrEmpty(Tags.RouteDescription))
					list.Add(new RouteFeature(RouteFeatureType.Description, Tags.RouteDescription));
				if (!String.IsNullOrEmpty(Tags.Color))
					list.Add(new RouteFeature(RouteFeatureType.Color, Tags.Color));
				if (!String.IsNullOrEmpty(Tags.TextColor))
					list.Add(new RouteFeature(RouteFeatureType.TextColor, Tags.TextColor));
			 }

			 return list;
		 }
	}
}
