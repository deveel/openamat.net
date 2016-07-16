using System;
using System.Collections.Generic;

namespace Deveel.OpenAmat {
	public interface ISchedule {
		ISchedulePoint[] Points { get; }

		string TripId { get; }

		string TripHeadSign { get; }

		IList<IScheduleFeature> Features { get; }
			
		DateTime ServiceStartDate { get; }

		DateTime ServiceEndDate { get; }

		DateTime[] ServiceExceptDates { get; }

		IDictionary<DayOfWeek, bool> ServiceDaysOfWeek { get; }

		DateTime CreatedAt { get; }

		DateTime UpdatedAt { get; }
	}
}
