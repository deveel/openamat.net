using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deveel.OpenAmat.Client {
	public interface IStopsManager {
		Task<IList<IStop>> ListStopsAsync(Paging paging);

		Task<IStop> FindByIdentifierAsync(string id);

		Task<IStop> FindByOneStopIdAsync(string id);

		Task<IList<IStop>> ListByDistanceAsync(RangeFilter filter);
	}
}
