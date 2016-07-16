using System;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class SchedulePoint : ISchedulePoint {
		public SchedulePoint(SchedulePointType pointType, string oneStopId) {
			PointType = pointType;
			OneStopId = oneStopId;
		}

		public SchedulePointType PointType { get; private set; }

		public string OneStopId { get; private set; }

		public string DepartureTime { get; set; }

		public string ArrivalTime { get; set; }

		public double DistanceTraveled { get; set; }

		public string TimeZone { get; set; }
	}
}
