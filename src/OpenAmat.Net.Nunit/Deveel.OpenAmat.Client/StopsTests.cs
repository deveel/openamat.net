using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Deveel.OpenAmat.Client {
	[TestFixture]
	public sealed class StopsTests : ClientTestBase {
		[Test]
		public async Task ListAllStops() {
			var stops = await Client.Stops.ListStopsAsync();

			Assert.IsNotNull(stops);
			Assert.IsNotEmpty(stops);

			var first = stops.FirstOrDefault();

			Assert.IsNotNull(first);
			Assert.IsNotNull(first.Name);
			Assert.IsNotNull(first.OneStopId);
			Assert.IsNotNull(first.Routes);
			Assert.IsNotNull(first.Operators);
			Assert.IsNotNull(first.Geometry);
			Assert.IsNotNull(first.Identifiers);
			Assert.IsNotNull(first.Features);
			Assert.IsNotEmpty(first.Features);
		}

		[TestCase("gtfs://f-sqc2-comunepalermo/s/433", "s-sqc8963wr2-ciaculli~croceverde")]
		public async Task FindById(string identifier, string expectedId) {
			var stop = await Client.Stops.FindByIdentifierAsync(identifier);

			Assert.IsNotNull(stop);
			Assert.IsNotNull(stop.OneStopId);
			Assert.AreEqual(expectedId, stop.OneStopId);
			Assert.IsNotEmpty(stop.Identifiers);
			Assert.Contains(identifier, (ICollection) stop.Identifiers);
			Assert.IsNotNull(stop.Name);
		}

		[TestCase(38.1255002, 13.353526, 200)]
		public async Task ListByDistance(double lat, double lon, int radius) {
			var stops = await Client.Stops.ListByDistanceAsync(new RangeFilter(lat, lon, radius));

			Assert.IsNotNull(stops);
			Assert.IsNotEmpty(stops);

			var first = stops.FirstOrDefault();

			Assert.IsNotNull(first);
			Assert.IsNotNull(first.Name);
			Assert.IsNotNull(first.OneStopId);
			Assert.IsNotNull(first.Routes);
			Assert.IsNotNull(first.Operators);
			Assert.IsNotNull(first.Geometry);
			Assert.IsNotNull(first.Identifiers);
		}

		[TestCase("s-sqc8963wr2-ciaculli~croceverde")]
		public async Task FindByOneStopId(string id) {
			var stop = await Client.Stops.FindByOneStopIdAsync(id);

			Assert.IsNotNull(stop);
			Assert.IsNotNull(stop.OneStopId);
			Assert.AreEqual(id, stop.OneStopId);
			Assert.IsNotEmpty(stop.Identifiers);
			Assert.IsNotNull(stop.Name);
		}
	}
}
