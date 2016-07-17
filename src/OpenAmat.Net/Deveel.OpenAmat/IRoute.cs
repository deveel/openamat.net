using System;
using System.Collections.Generic;

namespace Deveel.OpenAmat {
	public interface IRoute {
		string Name { get; }

		string OneStopId { get; }

		VehicleType VeihcleType { get; }

		IList<string> Identifiers { get; }
			
		DateTime CreatedAt { get; }

		DateTime UpdatedAt { get; }

		IList<IRouteStop> Stops { get; }

		IList<IRouteFeature> Features { get; }
	}
}
