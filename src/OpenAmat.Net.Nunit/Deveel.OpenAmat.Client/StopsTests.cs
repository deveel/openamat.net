using System;
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
		}
	}
}
