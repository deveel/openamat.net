using System;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class ScheduleFeature : IScheduleFeature {
		public ScheduleFeature(ScheduleFeatureType featureType, object value) {
			FeatureType = featureType;
			Value = value;
		}

		public ScheduleFeatureType FeatureType { get; private set; }

		public object Value { get; private set; }
	}
}
