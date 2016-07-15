using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Deveel.OpenAmat.Client.Serialization;
using Deveel.OpenAmat.Client.v1;

using DryIoc;

using RestSharp;
using RestSharp.Authenticators;

namespace Deveel.OpenAmat.Client {
	public sealed class OpenAmatClient {
		private RestClient client;
		private OpenAmatClientSettings settings;

		private Container serviceContainer;

		public OpenAmatClient() {
			
		}

		public OpenAmatClient(OpenAmatClientSettings settings) {
			Settings = settings;
		}

		public OpenAmatClientSettings Settings {
			get { return settings; }
			set {
				if (value == null)
					throw new ArgumentNullException("value");

				settings = value;
				settings.PropertyChanged += (sender, args) => Reset();
				Reset();
			}
		}

		public IRoutesManager Routes {
			get { return serviceContainer.Resolve<IRoutesManager>(Settings.Version); }
		}

		private void AssertConfigured() {
			if (Settings.BaseUrl == null)
				throw new InvalidOperationException("The client requires a base URL for the service.");

			if (Settings.Version == ClientVersion.v1 ||
			    Settings.Version == ClientVersion.v1a) {
				if (Settings.RequestFormat != RequestFormat.Json)
					throw new NotSupportedException("Only JSON format is supported for v1.");
			}
		}

		private void ConfigureServices() {
			serviceContainer = new Container(Rules.Default);
			serviceContainer.RegisterInstance(this);

			ConfigureV1aServices();
		}

		private void ConfigureV1aServices() {
			serviceContainer.Register<IRoutesManager, RoutesManager>(serviceKey:ClientVersion.v1a);
		}

		private void Reset() {
			AssertConfigured();

			ConfigureServices();

			client = new RestClient(Settings.BaseUrl);

			if (!String.IsNullOrEmpty(Settings.AuthenticationType)) {
				switch (Settings.AuthenticationType.ToUpperInvariant()) {
					case "BASIC": {
						client.Authenticator = new HttpBasicAuthenticator(Settings.UserName, Settings.Password);
						break;
					}
					default:
						throw new NotSupportedException(String.Format("Authentication type '{0} is not supported.", Settings.AuthenticationType));
				}
			}
		}

		private static void AddParameters(RestRequest request, ParameterType parameterType, object args) {
			if (args != null) {
				var pairs = args.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
					.ToDictionary(key => key.Name, value => value.GetValue(args));
				foreach (var pair in pairs) {
					request.AddParameter(pair.Key, pair.Value, parameterType);
				}
			}
		}

		internal async Task<T> GetAsync<T>(string resource, object args = null, object queryString = null) where T : class {
			var request = new RestRequest(resource, Method.GET);
			AddParameters(request, ParameterType.UrlSegment, args);
			AddParameters(request, ParameterType.QueryString, queryString);

			request.RequestFormat = Settings.RequestFormat == RequestFormat.Json ? DataFormat.Json : DataFormat.Xml;
			request.DateFormat = Settings.DateFormat;
			request.JsonSerializer = new JsonNetSerializer {
				DateFormat = Settings.DateFormat
			};

			var response = await client.ExecuteTaskAsync<T>(request);

			if (response.ResponseStatus == ResponseStatus.TimedOut)
				throw new TimeoutException("The request timed out");
			if (response.ResponseStatus == ResponseStatus.Aborted)
				throw new RequestAbortedException("The request was aborted", response.ErrorException);
			if (response.ResponseStatus == ResponseStatus.Error)
				throw new Exception("An error occurred while executing the request", response.ErrorException);

			return response.Data;
		}
	}
}
