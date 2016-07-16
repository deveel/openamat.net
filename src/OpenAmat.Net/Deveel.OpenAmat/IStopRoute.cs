using System;

namespace Deveel.OpenAmat {
	public interface IStopRoute {
		string OperatorName { get; }

		string OperatorId { get; }

		string RouteName { get; }

		string RouteId { get; }
	}
}
