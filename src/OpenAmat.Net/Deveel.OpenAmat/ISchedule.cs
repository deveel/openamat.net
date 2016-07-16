using System;
using System.Collections.Generic;

namespace Deveel.OpenAmat {
	public interface ISchedule {
		string OriginOneStopId { get; }

		string DestinationOneStopId { get; }

		string TripId { get; }

		string TripHeadSign { get; }

		string OriginDepartureTime { get; }

		string OriginArrivalTime { get; }

		string DestinationDepartureTime { get; }

		string DestinationArrivalTime { get; }

		DateTime ServiceStartDate { get; }

		DateTime ServiceEndDate { get; }

		DateTime[] ServiceExceptDates { get; }

		IDictionary<DayOfWeek, bool> ServiceDaysOfWeek { get; }

		DateTime CreatedAt { get; }

		DateTime UpdatedAt { get; }
	}
}
