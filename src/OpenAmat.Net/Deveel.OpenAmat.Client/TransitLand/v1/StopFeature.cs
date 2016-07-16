using System;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class StopFeature : IStopFeature {
		public StopFeature(StopFeatureType featureType, object value) {
			FeatureType = featureType;
			Value = value;
		}

		public StopFeatureType FeatureType { get; private set; }

		public object Value { get; private set; }
	}
}
