using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class SchedulesManager : IScheduleManager {
		public SchedulesManager(OpenAmatClient client) {
			Client = client;
		}

		public OpenAmatClient Client { get; private set; }

		public async Task<IList<Schedule>> ListSchedulesAsync() {
			return await Client.GetAsync<List<Schedule>>("schedule_stop_pairs",
				queryString: new {feed_onestop_id = "f-sqc2-comunepalermo"});
		}
	}
}
