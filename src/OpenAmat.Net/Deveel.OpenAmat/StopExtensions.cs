using System;
using System.Linq;

namespace Deveel.OpenAmat {
	public static class StopExtensions {
		public static object FeatureValue(this IStop stop, StopFeatureType featureType) {
			if (stop == null ||
			    stop.Features == null ||
			    stop.Features.Count == 0)
				return null;

			var feature = stop.Features.FirstOrDefault(x => x.FeatureType == featureType);
			return feature == null ? null : feature.Value;
		}

		public static string ZoneId(this IStop stop) {
			var value = stop.FeatureValue(StopFeatureType.ZoneId);
			return value == null ? null : (string) value;
		}

		public static string Description(this IStop stop) {
			var value = stop.FeatureValue(StopFeatureType.Description);
			return value == null ? null : (string)value;
		}

		public static string Url(this IStop stop) {
			var value = stop.FeatureValue(StopFeatureType.Url);
			return value == null ? null : (string)value;
		}

		public static bool WheelChairBoarding(this IStop stop) {
			var value = stop.FeatureValue(StopFeatureType.WheelChairBoarding);
			return value == null ? false : (bool)value;
		}

		public static string OsmWayId(this IStop stop) {
			var value = stop.FeatureValue(StopFeatureType.OsmWayId);
			return value == null ? null : (string)value;
		}
	}
}
