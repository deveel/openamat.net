using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deveel.OpenAmat.Client {
	public interface IRoutesManager {
		Task<IList<IRoute>> ListRoutesAsync(Paging paging);

		Task<IList<IRoute>> ListByVehicleTypeAsync(string vehicleType, Paging paging);

		Task<IRoute> FindByIdentifierAsync(string identifier);

		Task<IRoute> FindByOneStopIdAsync(string id);
	}
}
