using System;
using System.Linq;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Deveel.OpenAmat.Client {
	[TestFixture]
	public class RoutesTests : ClientTestBase {
		[Test]
		public async Task ListRoutes() {
			var routes = await Client.Routes.ListRoutesAsync();

			Assert.IsNotNull(routes);
			Assert.IsNotEmpty(routes);

			var first = routes.FirstOrDefault();

			Assert.IsNotNull(first);
			Assert.IsNotNull(first.Name);
			Assert.IsNotNull(first.VeihcleType);
			Assert.IsNotNull(first.Stops);
			Assert.IsNotEmpty(first.Stops);
		}

		[TestCase("bus")]
		public async Task ListRoutesByVehicleType(string vehicleType) {
			var routes = await Client.Routes.ListByVehicleType(vehicleType);

			Assert.IsNotNull(routes);
			Assert.IsNotEmpty(routes);

			var first = routes.FirstOrDefault();

			Assert.IsNotNull(first);
			Assert.IsNotNull(first.Name);
			Assert.IsNotNull(first.VeihcleType);
			Assert.IsNotNull(first.Stops);
			Assert.IsNotEmpty(first.Stops);
		}
	}
}
