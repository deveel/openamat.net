using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deveel.OpenAmat.Client {
	public interface IRoutesManager {
		Task<IList<Route>> ListRoutesAsync();
	}
}
