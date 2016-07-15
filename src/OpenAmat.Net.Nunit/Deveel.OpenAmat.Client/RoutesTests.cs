using System;
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
		}
	}
}
