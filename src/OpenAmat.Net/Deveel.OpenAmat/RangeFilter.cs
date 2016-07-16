using System;

namespace Deveel.OpenAmat {
	public sealed class RangeFilter {
		public RangeFilter(double latitude, double longitude, int distance) {
			Latitude = latitude;
			Longitude = longitude;
			Distance = distance;
			DistanceUnit = DistanceUnit.Default;
		}

		public double Longitude { get; private set; }

		public double Latitude { get; private set; }

		public int Distance { get; private set; }
		public DistanceUnit DistanceUnit { get; set; }
	}
}
