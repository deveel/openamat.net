using System;
using System.Collections.Generic;

namespace Deveel.OpenAmat {
	public interface IRoute {
		string Name { get; }

		string VeihcleType { get; }

		DateTime CreatedAt { get; }

		DateTime UpdatedAt { get; }

		IList<IRouteStop> Stops { get; }
	}
}
