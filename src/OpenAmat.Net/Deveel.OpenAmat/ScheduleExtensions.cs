using System;
using System.Linq;

namespace Deveel.OpenAmat {
	public static class ScheduleExtensions {
		public static ISchedulePoint FindPointByType(this ISchedule schedule, SchedulePointType type) {
			if (schedule == null ||
			    schedule.Points == null ||
			    schedule.Points.Length == 0)
				return null;

			return schedule.Points.FirstOrDefault(x => x.PointType == type);
		}

		public static ISchedulePoint Origin(this ISchedule schedule) {
			return schedule.FindPointByType(SchedulePointType.Origin);
		}

		public static ISchedulePoint Destination(this ISchedule schedule) {
			return schedule.FindPointByType(SchedulePointType.Destination);
		}

		public static object FeatureValue(this ISchedule schedule, ScheduleFeatureType featureType) {
			if (schedule == null ||
			    schedule.Features == null ||
			    schedule.Features.Count == 0)
				return null;

			var feature = schedule.Features.FirstOrDefault(x => x.FeatureType == featureType);
			return feature == null ? null : feature.Value;
		}

		public static bool BikesAllowed(this ISchedule schedule) {
			var value = schedule.FeatureValue(ScheduleFeatureType.BikesAllowed);
			return value == null ? false : (bool) value;
		}

		public static bool WheelChairAccessible(this ISchedule schedule) {
			var value = schedule.FeatureValue(ScheduleFeatureType.WheelChairAcessible);
			return value == null ? false : (bool)value;
		}

		public static string PickupType(this ISchedule schedule) {
			var value = schedule.FeatureValue(ScheduleFeatureType.PickupType);
			return value == null ? null : (string)value;
		}

		public static string DropOffType(this ISchedule schedule) {
			var value = schedule.FeatureValue(ScheduleFeatureType.DropOffType);
			return value == null ? null : (string)value;
		}
	}
}
