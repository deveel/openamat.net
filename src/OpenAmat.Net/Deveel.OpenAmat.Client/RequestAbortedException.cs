using System;

namespace Deveel.OpenAmat.Client {
	public sealed class RequestAbortedException : Exception {
		internal RequestAbortedException(string message, Exception innerException)
			: base(message, innerException) {
		}
	}
}
