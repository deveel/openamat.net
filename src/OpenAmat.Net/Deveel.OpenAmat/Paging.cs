using System;

namespace Deveel.OpenAmat {
	public sealed class Paging {
		public Paging() {
			Offset = 0;
			Count = 10;
			SortOrder = SortOrder.Default;
		}

		public int Offset { get; set; }

		public int Count { get; set; }

		public string SortKey { get; set; }

		public SortOrder SortOrder { get; set; }
	}
}
