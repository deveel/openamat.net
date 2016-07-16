using System;
using System.Collections.Generic;

namespace Deveel.OpenAmat {
	public interface IStop {
		string Name { get; }

		string Id { get; }

		IList<string> Identifiers { get; }
			
		DateTime CreatedAt { get; }

		DateTime UpdatedAt { get; }

		IList<IStopFeature> Features { get; }
		
		IStopGeometry Geometry { get; }

		IList<IStopOperator> Operators { get; }

		IList<IStopRoute> Routes { get; }
	}
}
