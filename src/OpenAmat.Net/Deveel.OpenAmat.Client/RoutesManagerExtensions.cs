using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Deveel.OpenAmat.Util;

namespace Deveel.OpenAmat.Client {
	public static class RoutesManagerExtensions {
		public static async Task<IList<IRoute>> ListRoutesAsync(this IRoutesManager manager) {
			return await manager.ListRoutesAsync(new Paging());
		}

		public static async Task<IList<IRoute>> ListByVehicleTypeAsync(this IRoutesManager manager, VehicleType vehicleType) {
			return await manager.ListByVehicleTypeAsync(vehicleType, new Paging());
		}

		public static IList<IRoute> ListRoutes(this IRoutesManager manager, Paging paging) {
			return manager.ListRoutesAsync(paging).RunSync();
		}

		public static IList<IRoute> ListRoutes(this IRoutesManager manager) {
			return manager.ListRoutes(new Paging());
		}

		public static IList<IRoute> ListByVehicleType(this IRoutesManager manager, VehicleType vehicleType) {
			return ListByVehicleType(manager, vehicleType, new Paging());
		}

		public static IList<IRoute> ListByVehicleType(this IRoutesManager manager, VehicleType vehicleType, Paging paging) {
			return manager.ListByVehicleTypeAsync(vehicleType, paging).RunSync();
		}
	}
}
