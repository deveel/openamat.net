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

		[JsonProperty("origin_dist_traveled")]
		public double OriginDistanceTraveled { get; set; }

		[JsonProperty("destination_dist_traveled")]
		public double DestinationDistanceTraveled { get; set; }

		[JsonProperty("origin_timezone")]
		public string OriginTimeZone { get; set; }

		[JsonProperty("destination_timezone")]
		public string DestinationTimeZone { get; set; }

		[JsonProperty("service_start_date")]
		public DateTime ServiceStartDate { get; private set; }

		[JsonProperty("service_end_date")]
		public DateTime ServiceEndDate { get; private set; }

		[JsonProperty("service_except_dates")]
		public DateTime[] ServiceExceptDates { get; private set; }

		[JsonProperty("service_days_of_week")]
		public bool[] ServiceDaysOfWeek { get; private set; }

		public ISchedulePoint[] Points {
			get {
				return new ISchedulePoint[] {
					new SchedulePoint(SchedulePointType.Origin, OriginOneStopId) {
						ArrivalTime = OriginArrivalTime,
						DepartureTime = OriginDepartureTime,
						TimeZone = OriginTimeZone,
						DistanceTraveled = OriginDistanceTraveled
					},
					new SchedulePoint(SchedulePointType.Destination, DestinationOneStopId) {
						DepartureTime = DestinationDepartureTime,
						ArrivalTime = DestinationArrivalTime,
						TimeZone = DestinationTimeZone,
						DistanceTraveled = DestinationDistanceTraveled
					} 
				};
			}
		}

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

		[JsonProperty("wheelchair_accessible")]
		public string WheelChairAccessible { get; set; }

		[JsonProperty("bikes_allowed")]
		public string BikesAllowed { get; set; }

		[JsonProperty(("pickup_type"))]
		public string PickUpType { get; set; }

		[JsonProperty("drop_off_type")]
		public string DropOffType { get; set; }

		public IList<IScheduleFeature> Features {
			get {
				var list = new List<IScheduleFeature>();

				if (!String.IsNullOrEmpty(WheelChairAccessible)) {
					var value = String.Equals(WheelChairAccessible, "1");
					list.Add(new ScheduleFeature(ScheduleFeatureType.WheelChairAcessible, value));
				}

				if (!String.IsNullOrEmpty(BikesAllowed)) {
					var value = String.Equals(BikesAllowed, "1");
					list.Add(new ScheduleFeature(ScheduleFeatureType.BikesAllowed, value));
				}

				if (!String.IsNullOrEmpty(PickUpType))
					list.Add(new ScheduleFeature(ScheduleFeatureType.PickupType, PickUpType));

				if (!String.IsNullOrEmpty(DropOffType))
					list.Add(new ScheduleFeature(ScheduleFeatureType.DropOffType, DropOffType));

				return list;
			}
		}
	}
}
