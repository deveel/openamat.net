using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Deveel.OpenAmat.Util;

namespace Deveel.OpenAmat.Client {
	public static class ScheduleManagerExtensions {
		public static async Task<IList<ISchedule>> ListSchedulesAsync(this IScheduleManager manager) {
			return await manager.ListSchedulesAsync(new Paging());
		}

		public static IList<ISchedule> ListSchedules(this IScheduleManager manager, Paging paging) {
			return manager.ListSchedulesAsync(paging).RunSync();
		}

		public static IList<ISchedule> ListSchedules(this IScheduleManager manager) {
			return manager.ListSchedules(new Paging());
		}
	}
}
