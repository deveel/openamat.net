using System;
using System.Linq;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Deveel.OpenAmat.Client {
	[TestFixture]
	public sealed class ScheduleTests : ClientTestBase {
		[Test]
		public async Task ListSchedules() {
			var schedules = await Client.Schedules.ListSchedulesAsync();

			Assert.IsNotNull(schedules);
			Assert.IsNotEmpty(schedules);

			var first = schedules.FirstOrDefault();

			Assert.IsNotNull(first);
			Assert.IsNotNull(first.OriginOneStopId);
			Assert.IsNotNull(first.DestinationOneStopId);
		}
	}
}
