using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class StopsManager : IStopsManager {
		public StopsManager(OpenAmatClient client) {
			Client = client;
		}

		public OpenAmatClient Client { get; private set; }

		public async Task<IList<Stop>> ListStopsAsync() {
			var result = await Client.GetAsync<StopsRoot>("stops", queryString: new { served_by = "o-sqc2-amatpalermospa" });
			if (result == null)
				return new Stop[0];

			return result.Stops;
		}

		class StopsRoot {
			public List<Stop> Stops { get; set; }
		}
	}
}
