using System;

using NUnit.Framework;

namespace Deveel.OpenAmat.Client {
	[TestFixture]
	public abstract class ClientTestBase {
		protected OpenAmatClient Client { get; private set; }

		[SetUp]
		public void SetUp() {
			Client = new OpenAmatClient(new OpenAmatClientSettings {
				BaseUrl = new Uri("http://www.weathersicily.it/Amat/API/"),
				Version = ClientVersion.v1a
			});

			OnSetUp();
		}

		protected virtual void OnSetUp() {
			
		}
	}
}
