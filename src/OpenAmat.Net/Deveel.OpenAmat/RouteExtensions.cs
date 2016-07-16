using System;
using System.Linq;

namespace Deveel.OpenAmat {
	public static class RouteExtensions {
		public static object FeatureValue(this IRoute route, RouteFeatureType featureType) {
			if (route == null ||
			    route.Features == null ||
			    route.Features.Count == 0)
				return null;

			var feature = route.Features.FirstOrDefault(x => x.FeatureType == featureType);
			return feature == null ? null : feature.Value;
		}

		public static string LongName(this IRoute route) {
			var value = route.FeatureValue(RouteFeatureType.LongName);
			return value == null ? null : (string) value;
		}

		public static string Description(this IRoute route) {
			var value = route.FeatureValue(RouteFeatureType.Description);
			return value == null ? null : (string)value;
		}

		public static string Url(this IRoute route) {
			var value = route.FeatureValue(RouteFeatureType.Url);
			return value == null ? null : (string)value;
		}

		public static string TextColor(this IRoute route) {
			var value = route.FeatureValue(RouteFeatureType.TextColor);
			return value == null ? null : (string)value;
		}

		public static string Color(this IRoute route) {
			var value = route.FeatureValue(RouteFeatureType.Color);
			return value == null ? null : (string)value;
		}
	}
}
