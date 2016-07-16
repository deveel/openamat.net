using System;
using System.Collections;
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
			Assert.IsNotNull(first.OneStopId);
			Assert.IsNotNull(first.VeihcleType);
			Assert.IsNotNull(first.Stops);
			Assert.IsNotEmpty(first.Stops);
		}

		[TestCase("bus")]
		public async Task ListRoutesByVehicleType(string vehicleType) {
			var routes = await Client.Routes.ListByVehicleTypeAsync(vehicleType);

			Assert.IsNotNull(routes);
			Assert.IsNotEmpty(routes);

			var first = routes.FirstOrDefault();

			Assert.IsNotNull(first);
			Assert.IsNotNull(first.Name);
			Assert.IsNotNull(first.VeihcleType);
			Assert.IsNotNull(first.Stops);
			Assert.IsNotEmpty(first.Stops);
		}

		[TestCase("gtfs://f-sqc2-comunepalermo/r/212")]
		public async Task FindByIdentifier(string id) {
			var route = await Client.Routes.FindByIdentifierAsync(id);

			Assert.IsNotNull(route);
			Assert.IsNotNull(route.Name);
			Assert.IsNotNull(route.Identifiers);
			Assert.IsNotEmpty(route.Identifiers);
			Assert.IsInstanceOf<ICollection>(route.Identifiers);
			Assert.Contains(id, (ICollection)route.Identifiers);
		}

		[TestCase("r-sqc88-212")]
		public async Task FindByOneStopId(string id) {
			var route = await Client.Routes.FindByOneStopIdAsync(id);

			Assert.IsNotNull(route);
			Assert.IsNotNull(route.Name);
			Assert.IsNotNull(route.OneStopId);
			Assert.AreEqual(id, route.OneStopId);
			Assert.IsNotNull(route.Identifiers);
			Assert.IsNotEmpty(route.Identifiers);
		}
	}
}
