using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class RoutesManager : IRoutesManager {
		public RoutesManager(OpenAmatClient client) {
			Client = client;
		}

		public OpenAmatClient Client { get; private set; }

		public async Task<IList<IRoute>> ListRoutesAsync(Paging paging) {
			var queryString = PagingUtil.GetPaging(new {operated_by = "o-sqc2-amatpalermospa" }, paging);

			var result = await Client.GetAsync<RoutesRoot>("routes", queryString: queryString);
			if (result == null)
				return new Route[0];

			return result.Routes.Cast<IRoute>().ToList();
		}

		public async Task<IList<IRoute>> ListByVehicleTypeAsync(VehicleType vehicleType, Paging paging) {
			var queryString = PagingUtil.GetPaging(new {
				operated_by = "o-sqc2-amatpalermospa",
				vehicle_type = vehicleType.ToString().ToLowerInvariant()
			}, paging);

			var result = await Client.GetAsync<RoutesRoot>("routes", queryString: queryString);
			if (result == null)
				return new Route[0];

			return result.Routes.Cast<IRoute>().ToList();
		}

		public async Task<IRoute> FindByIdentifierAsync(string identifier) {
			var result = await Client.GetAsync<RoutesRoot>("routes", queryString: new {
				identifier,
			});

			if (result == null ||
			    result.Routes == null ||
			    result.Routes.Count == 0)
				return null;

			return result.Routes.FirstOrDefault();
		}

		public async Task<IRoute> FindByOneStopIdAsync(string id) {
			return await Client.GetAsync<Route>("onestop_id/{id}", new {id});
		}

		class RoutesRoot {
			public List<Route> Routes { get; set; }
		}
	}
}
