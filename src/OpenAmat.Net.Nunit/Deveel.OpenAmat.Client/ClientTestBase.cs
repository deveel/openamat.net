using System;

using NUnit.Framework;

namespace Deveel.OpenAmat.Client {
	[TestFixture]
	public abstract class ClientTestBase {
		protected OpenAmatClient Client { get; private set; }

		[SetUp]
		public void SetUp() {
			Client = new OpenAmatClient(new OpenAmatClientSettings {
				SourceType = SourceType.TransitLandV1
			});

			OnSetUp();
		}

		protected virtual void OnSetUp() {
			
		}
	}
}
