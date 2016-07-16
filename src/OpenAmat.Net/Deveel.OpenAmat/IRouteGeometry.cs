using System;
using System.Collections.Generic;

namespace Deveel.OpenAmat {
	public interface IRouteGeometry {
		GeometryType Type { get; }

		IList<IList<double[]>> Coordinates { get; }
	}
}
