using System;

using Newtonsoft.Json;

namespace Deveel.OpenAmat {
	public class Route {
		[JsonProperty("short_name")]
		public string ShortName { get; private set; }

		[JsonProperty("long_name")]
		public string LongName { get; private set; }
	}
}
