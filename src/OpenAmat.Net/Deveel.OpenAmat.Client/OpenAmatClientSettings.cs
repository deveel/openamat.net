using System;

namespace Deveel.OpenAmat.Client {
	public sealed class OpenAmatClientSettings {
		private ClientVersion version;
		private Uri baseUrl;
		private RequestFormat format;
		private string dateFormat;

		private string userName;
		private string password;
		private string authType;

		public OpenAmatClientSettings() {
			version = ClientVersion.v1a;
			format = RequestFormat.Json;
			dateFormat = "yyyy-MM-ddTHH:mm:ss";
		}

		public Uri BaseUrl {
			get { return baseUrl; }
			set {
				if (value == null)
					throw new ArgumentNullException("value");

				baseUrl = value;
				OnPropertyChanged();
			}
		}

		public ClientVersion Version {
			get { return version; }
			set {
				version = value;
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
