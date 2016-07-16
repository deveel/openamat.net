using System;

namespace Deveel.OpenAmat {
	public interface IStopGeometry {
		GeometryType Type { get; }

		double[] Coordinates { get; }
	}
}
