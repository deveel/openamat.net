using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deveel.OpenAmat.Client {
	public interface IRoutesManager {
		Task<IList<IRoute>> ListRoutesAsync();

		Task<IList<IRoute>> ListByVehicleType(string vehicleType);
	}
}
