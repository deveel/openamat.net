using System;

namespace Deveel.OpenAmat {
	public interface ISchedulePoint {
		SchedulePointType PointType { get; }

		string OneStopId { get; }

		string DepartureTime { get; }

		string ArrivalTime { get; }

		double DistanceTraveled { get; }

		string TimeZone { get; }
	}
}
