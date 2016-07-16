using System;

namespace Deveel.OpenAmat {
	public interface IStopFeature {
		StopFeatureType FeatureType { get; }

		object Value { get; }
	}
}
