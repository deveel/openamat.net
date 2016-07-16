using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Deveel.OpenAmat.Util;

namespace Deveel.OpenAmat.Client {
	public static class StopsManagerExtensions {
		public static async Task<IList<IStop>> ListStopsAsync(this IStopsManager manager) {
			return await manager.ListStopsAsync(new Paging());
		}

		public static IList<IStop> ListStops(this IStopsManager manager, Paging paging) {
			return manager.ListStopsAsync(paging).RunSync();
		}

		public static IList<IStop> ListStops(this IStopsManager manager) {
			return manager.ListStops(new Paging());
		}
	}
}
