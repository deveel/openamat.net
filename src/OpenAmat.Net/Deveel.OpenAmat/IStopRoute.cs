using System;

namespace Deveel.OpenAmat {
	public interface IStopRoute {
		string OperatorName { get; }

		string OperatorOneStopId { get; }

		string RouteName { get; }

		string RouteOneStopId { get; }
	}
}
