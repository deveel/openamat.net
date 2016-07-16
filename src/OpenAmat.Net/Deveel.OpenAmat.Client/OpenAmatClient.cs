using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Deveel.OpenAmat.Client.TransitLand.v1;

using DryIoc;

using Newtonsoft.Json;

namespace Deveel.OpenAmat.Client {
	public sealed class OpenAmatClient : IDisposable {
		private HttpClient client;
		private OpenAmatClientSettings settings;

		private Container serviceContainer;

		public OpenAmatClient() {
			
		}

		public OpenAmatClient(OpenAmatClientSettings settings) {
			Settings = settings;
		}

		~OpenAmatClient() {
			Dispose(false);
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

		private void Dispose(bool disposing) {
			if (disposing) {
				if (client != null)
					client.Dispose();
			}

			client = null;
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
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

			client = new HttpClient {
				BaseAddress = baseUrl
			};
		}

		private void SetupAuthentication(HttpRequestMessage request) {
			if (!String.IsNullOrEmpty(Settings.AuthenticationType)) {
				switch (Settings.AuthenticationType.ToUpperInvariant()) {
					case "BASIC": {
							request.Headers.Authorization = new AuthenticationHeaderValue("BASIC", CalculateBasicAuth(Settings.UserName, Settings.Password));
							break;
						}
					default:
						throw new NotSupportedException(String.Format("Authentication type '{0} is not supported.", Settings.AuthenticationType));
				}
			}
		}

		private string CalculateBasicAuth(string userName, string password) {
			throw new NotImplementedException();
		}

		private Uri FormRequestUri(string resource, object args, object queryString) {
			var uriBuilder = new UriBuilder(client.BaseAddress);
			var path = uriBuilder.Path;

			if (args != null) {
				var pairs = GetParameters(args);
				foreach (var pair in pairs) {
					var key = new StringBuilder().Append('{').Append(pair.Key).Append('}').ToString();
					resource = resource.Replace(key, pair.Value.ToString());
				}
			}

			if (string.IsNullOrEmpty(path)) {
				uriBuilder.Path = resource;
			} else {
				if (path[path.Length - 1] == '/')
					path = path.Substring(0, path.Length-1);

				uriBuilder.Path = String.Format("{0}/{1}", path, resource);
			}

			if (queryString != null) {
				var qs = GetParameters(queryString);
				uriBuilder.Query = String.Join("&", qs.Select(pair => String.Format("{0}={1}", pair.Key, pair.Value)));
			}

			return uriBuilder.Uri;
		}

		private static Dictionary<string, object> GetParameters(object args) {
			var pairs = new Dictionary<string, object>();
			if (args != null) {
#if PCL
				pairs = args.GetType().GetRuntimeProperties()
					.ToDictionary(key => key.Name, value => value.GetValue(args));
#else
				pairs = args.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
					.ToDictionary(key => key.Name, value => value.GetValue(args));
#endif
			}

			return pairs;
		}

		private HttpRequestMessage MakeRequest(HttpMethod method, string resource, object args, object queryString = null) {
			var requestUri = FormRequestUri(resource, args, queryString);
			var request = new HttpRequestMessage(method, requestUri);
			SetupAuthentication(request);

			return request;
		}

		private void SetRequestFormat(HttpRequestMessage request) {
			if (Settings.RequestFormat == RequestFormat.Json) {
				request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			} else if (Settings.RequestFormat == RequestFormat.Xml) {
				request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
			}
		}

		internal async Task<T> GetAsync<T>(string resource, object args = null, object queryString = null) where T : class {
			var request = MakeRequest(HttpMethod.Get, resource, args, queryString);

			SetRequestFormat(request);

			var response = await client.SendAsync(request);

			response = response.EnsureSuccessStatusCode();

			try {
				var content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(content, new JsonSerializerSettings {
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
