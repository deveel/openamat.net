using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class StopsManager : IStopsManager {
		public StopsManager(OpenAmatClient client) {
			Client = client;
		}

		public OpenAmatClient Client { get; private set; }

		public async Task<IList<IStop>> ListStopsAsync(Paging paging) {
			var queryString = PagingUtil.GetPaging(new {served_by = "o-sqc2-amatpalermospa" }, paging);

			var result = await Client.GetAsync<StopsRoot>("stops", queryString: queryString);
			if (result == null)
				return new Stop[0];

			return result.Stops.Cast<IStop>().ToList();
		}

		public async Task<IStop> FindByIdentifierAsync(string id) {
			if (String.IsNullOrEmpty(id))
				throw new ArgumentNullException("id");

			var result = await Client.GetAsync<StopsRoot>("stops", queryString: new {
				served_by = "o-sqc2-amatpalermospa",
				identifier = id
			});

			if (result.Stops == null || result.Stops.Count == 0)
				return null;

			return result.Stops.FirstOrDefault();
		}

		public async Task<IStop> FindByOneStopIdAsync(string id) {
			return await Client.GetAsync<Stop>("onestop_id/{id}", new {id});
		}

		public async Task<IList<IStop>> ListByDistanceAsync(RangeFilter filter) {
			if (filter == null)
				throw new ArgumentNullException("filter");

			if (filter.DistanceUnit != DistanceUnit.Default &&
			    filter.DistanceUnit != DistanceUnit.Meters)
				throw new ArgumentException(String.Format("Distance unit '{0}' is not supported.", filter.DistanceUnit));

			var result = await Client.GetAsync<StopsRoot>("stops", queryString: new {
				served_by = "o-sqc2-amatpalermospa",
				lat = filter.Latitude,
				lon = filter.Longitude,
				r = filter.Distance
			});

			return result.Stops.Cast<IStop>().ToList();
		}

		class StopsRoot {
			public List<Stop> Stops { get; set; }
		}
	}
}
