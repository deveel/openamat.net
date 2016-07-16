using System;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class RouteFeature : IRouteFeature {
		public RouteFeature(RouteFeatureType featureType, object value) {
			FeatureType = featureType;
			Value = value;
		}

		public RouteFeatureType FeatureType { get; private set; }

		public object Value { get; private set; }
	}
}
