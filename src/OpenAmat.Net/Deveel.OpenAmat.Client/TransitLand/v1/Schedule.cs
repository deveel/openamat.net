using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class Schedule : ISchedule {
		[JsonProperty("origin_onestop_id")]
		public string OriginOneStopId { get; private set; }

		[JsonProperty("destination_onestop_id")]
		public string DestinationOneStopId { get; private set; }

		[JsonProperty("trip")]
		public string TripId { get; private set; }

		[JsonProperty("trip_headsign")]
		public string TripHeadSign { get; private set; }

		[JsonProperty("origin_arrival_time")]
		public string OriginArrivalTime { get; private set; }

		[JsonProperty("origin_departure_time")]
		public string OriginDepartureTime { get; private set; }

		[JsonProperty("destinarion_arrival_time")]
		public string DestinationArrivalTime { get; private set; }

		[JsonProperty("destination_departure_time")]
		public string DestinationDepartureTime { get; private set; }

		[JsonProperty("service_start_date")]
		public DateTime ServiceStartDate { get; private set; }

		[JsonProperty("service_end_date")]
		public DateTime ServiceEndDate { get; private set; }

		[JsonProperty("service_except_dates")]
		public DateTime[] ServiceExceptDates { get; private set; }

		[JsonProperty("service_days_of_week")]
		public bool[] ServiceDaysOfWeek { get; private set; }

		IDictionary<DayOfWeek, bool> ISchedule.ServiceDaysOfWeek {
			get {
				if (ServiceDaysOfWeek == null)
					return new Dictionary<DayOfWeek, bool>();

				return ServiceDaysOfWeek.Select((value, offset) => new {day = (DayOfWeek) offset, value})
					.ToDictionary(key => key.day, value => value.value);
			}
		}

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; private set; }

		[JsonProperty("updated_at")]
		public DateTime UpdatedAt { get; private set; }
	}
}
