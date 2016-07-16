using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	class SchedulesManager : IScheduleManager {
		public SchedulesManager(OpenAmatClient client) {
			Client = client;
		}

		public OpenAmatClient Client { get; private set; }

		public async Task<IList<ISchedule>> ListSchedulesAsync(Paging paging) {
			var queryString = PagingUtil.GetPaging(new {feed_onestop_id = "f-sqc2-comunepalermo"}, paging);

			var result = await Client.GetAsync<ScheduleRoot>("schedule_stop_pairs",
				queryString: queryString);

			if (result == null)
				return new Schedule[0];

			return result.ScheduleStopPairs.Cast<ISchedule>().ToArray();
		}

		class ScheduleRoot {
			[JsonProperty("schedule_stop_pairs")]
			public List<Schedule> ScheduleStopPairs { get; set; }
		}
	}
}
