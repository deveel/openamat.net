using System;

namespace Deveel.OpenAmat.Client {
	public sealed class OpenAmatClientSettings {
		private SourceType sourceType;
		private Uri baseUrl;
		private RequestFormat format;
		private string dateFormat;

		private string userName;
		private string password;
		private string authType;

		public OpenAmatClientSettings() {
			sourceType = SourceType.Default;
			format = RequestFormat.Json;
			dateFormat = "yyyy-MM-ddTHH:mm:ss";
		}

		public Uri BaseUrl {
			get { return baseUrl; }
			set {
				if (value == null)
					throw new ArgumentNullException("value");

				sourceType = SourceType.Custom;
				baseUrl = value;
				OnPropertyChanged();
			}
		}

		public SourceType SourceType {
			get { return sourceType; }
			set {
				sourceType = value;
				OnPropertyChanged();
			}
		}

		public RequestFormat RequestFormat {
			get { return format; }
			set {
				format = value;
				OnPropertyChanged();
			}
		}

		public string UserName {
			get { return userName; }
			set {
				userName = value;
				OnPropertyChanged();
			}
		}

		public string Password {
			get { return password; }
			set {
				password = value;
				OnPropertyChanged();
			}
		}

		public string AuthenticationType {
			get { return authType; }
			set {
				authType = value;
				OnPropertyChanged();
			}
		}

		public string DateFormat {
			get { return dateFormat; }
			set {
				dateFormat = value;
				OnPropertyChanged();
			}
		}

		private void OnPropertyChanged() {
			if (PropertyChanged != null)
				PropertyChanged(this, EventArgs.Empty);
		}

		internal event EventHandler PropertyChanged;
	}
}
