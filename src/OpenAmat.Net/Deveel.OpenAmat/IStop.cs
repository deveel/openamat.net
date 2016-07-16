using System;
using System.Collections.Generic;

namespace Deveel.OpenAmat {
	public interface IStop {
		string Name { get; }

		string Id { get; }

		DateTime CreatedAt { get; }

		DateTime UpdatedAt { get; }

		IStopGeometry Geometry { get; }

		IList<IStopOperator> Operators { get; }

		IList<IStopRoute> Routes { get; }
	}
}
