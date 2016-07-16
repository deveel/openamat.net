using System;

namespace Deveel.OpenAmat {
	public interface IScheduleFeature {
		ScheduleFeatureType FeatureType { get; }

		object Value { get; }
	}
}
