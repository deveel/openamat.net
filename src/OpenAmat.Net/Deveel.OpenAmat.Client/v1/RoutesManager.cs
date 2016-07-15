using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deveel.OpenAmat.Client.v1 {
	class RoutesManager : IRoutesManager {
		public RoutesManager(OpenAmatClient client) {
			Client = client;
		}

		public OpenAmatClient Client { get; private set; }

		public async Task<IList<Route>> ListRoutesAsync() {
			return await Client.GetAsync<IList<Route>>("routes.php");
		}
	}
}
