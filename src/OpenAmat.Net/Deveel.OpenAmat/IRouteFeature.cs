using System;

namespace Deveel.OpenAmat {
	public interface IRouteFeature {
		RouteFeatureType FeatureType { get; }

		object Value { get; }
	}
}
