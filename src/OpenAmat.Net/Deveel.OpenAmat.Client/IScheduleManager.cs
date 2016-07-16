using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deveel.OpenAmat.Client {
	public interface IScheduleManager {
		Task<IList<ISchedule>> ListSchedulesAsync(Paging paging);

		Task<IList<ISchedule>> ListByRouteOneStopeIdAsync(string id);
	}
}
