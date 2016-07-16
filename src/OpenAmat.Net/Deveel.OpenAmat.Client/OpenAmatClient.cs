using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Deveel.OpenAmat.Client.Serialization;
using Deveel.OpenAmat.Client.TransitLand.v1;

using DryIoc;

using Newtonsoft.Json;

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
			get { return serviceContainer.Resolve<IRoutesManager>(Settings.SourceType); }
		}

		public IScheduleManager Schedules {
			get { return serviceContainer.Resolve<IScheduleManager>(Settings.SourceType); }
		}

		public IStopsManager Stops {
			get { return serviceContainer.Resolve<IStopsManager>(Settings.SourceType); }
		}

		private void AssertConfigured() {
			if (Settings.SourceType == SourceType.TransitLandV1 ||
				Settings.SourceType == SourceType.Default) {
				if (Settings.RequestFormat != RequestFormat.Json)
					throw new NotSupportedException("Only JSON format is supported for Transit.land Feeds.");
			} else if (Settings.SourceType == SourceType.Custom) {
				if (Settings.BaseUrl == null)
					throw new InvalidOperationException("The client requires a base URL for the custom service.");

			}
		}

		private void ConfigureServices() {
			serviceContainer = new Container(Rules.Default);
			serviceContainer.RegisterInstance(this);

			ConfigureTransitLandV1();
		}

		private void ConfigureTransitLandV1() {
			serviceContainer.Register<IRoutesManager, RoutesManager>(serviceKey:SourceType.TransitLandV1);
			serviceContainer.Register<IStopsManager, StopsManager>(serviceKey:SourceType.TransitLandV1);
			serviceContainer.Register<IScheduleManager, SchedulesManager>(serviceKey:SourceType.TransitLandV1);
		}

		private Uri FindBaseUrl() {
			switch (Settings.SourceType) {
				case SourceType.Custom:
					return Settings.BaseUrl;
				case SourceType.TransitLandV1:
				case SourceType.Default:
					return new Uri(KnownServiceEndPoints.TransitLandV1);
				default:
					throw new InvalidOperationException("Invalid source type");
			}
		}

		private void Reset() {
			AssertConfigured();

			ConfigureServices();

			var baseUrl = FindBaseUrl();

			client = new RestClient(baseUrl);

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

			var response = await client.ExecuteTaskAsync(request);

			if (response.ResponseStatus == ResponseStatus.TimedOut)
				throw new TimeoutException("The request timed out");
			if (response.ResponseStatus == ResponseStatus.Aborted)
				throw new RequestAbortedException("The request was aborted", response.ErrorException);
			if (response.ResponseStatus == ResponseStatus.Error)
				throw new Exception("An error occurred while executing the request", response.ErrorException);

			try {
				return JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings {
					ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
					DateFormatString = Settings.DateFormat,
					DateParseHandling = DateParseHandling.DateTime
				});
			} catch (Exception ex) {
				throw new InvalidOperationException("Unable to deserialize the response", ex);
			}
		}
	}
}
