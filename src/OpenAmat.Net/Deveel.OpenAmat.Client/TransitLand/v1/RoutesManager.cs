using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class RoutesManager : IRoutesManager {
		public RoutesManager(OpenAmatClient client) {
			Client = client;
		}

		public OpenAmatClient Client { get; private set; }

		public async Task<IList<Route>> ListRoutesAsync() {
			var result = await Client.GetAsync<RoutesRoot>("routes", queryString: new {operated_by = "o-sqc2-amatpalermospa"});
			if (result == null)
				return new Route[0];

			return result.Routes;
		}

		class RoutesRoot {
			public List<Route> Routes { get; set; }
		}
	}
}
