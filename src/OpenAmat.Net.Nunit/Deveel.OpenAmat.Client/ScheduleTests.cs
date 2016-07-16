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
			Assert.IsNotNull(first.Points);
			Assert.IsNotEmpty(first.Points);
			Assert.AreEqual(2, first.Points.Length);
		}

		[TestCase("r-sqc3q-936")]
		public async Task ListByOneStopId(string routeId) {
			var schedules = await Client.Schedules.ListByRouteOneStopeIdAsync(routeId);

			Assert.IsNotNull(schedules);
			Assert.IsNotEmpty(schedules);

			var first = schedules.FirstOrDefault();

			Assert.IsNotNull(first);
			Assert.IsNotNull(first.Points);
			Assert.IsNotEmpty(first.Points);
			Assert.AreEqual(2, first.Points.Length);
		}
	}
}
