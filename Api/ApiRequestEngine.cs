using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Memenim.Core.Schema;
using Newtonsoft.Json;

namespace Memenim.Core.Api
{
    public static class ApiRequestEngine
    {
        public static event EventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged;

#if NETCOREAPP
        private static readonly SocketsHttpHandler HttpHandler;
#elif NETSTANDARD
        private static readonly HttpClientHandler HttpHandler;
#endif
        private static readonly HttpClient HttpClient;
        private static readonly JsonSerializerSettings JsonSettings;

        private static volatile ConnectionStateType _connectionState;
        public static ConnectionStateType ConnectionState
        {
            get
            {
                return _connectionState;
            }
        }

        static ApiRequestEngine()
        {
#if NETCOREAPP
            HttpHandler = new SocketsHttpHandler
            {
                MaxConnectionsPerServer = int.MaxValue
            };
#elif NETSTANDARD
            HttpHandler = new HttpClientHandler
            {
                MaxConnectionsPerServer = int.MaxValue
            };
#endif
            HttpClient = new HttpClient(HttpHandler)
            {
                Timeout = TimeSpan.FromMinutes(5)
            };
            JsonSettings = new JsonSerializerSettings
            {
                EqualityComparer = StringComparer.OrdinalIgnoreCase
            };

            _connectionState = ConnectionStateType.Connected;
        }

        public static void OnConnectionStateChanged(ConnectionStateType newState)
        {
            OnConnectionStateChanged(null, newState);
        }
        public static void OnConnectionStateChanged(object sender, ConnectionStateType newState)
        {
            if (_connectionState == newState)
                return;

            var oldState = _connectionState;
            _connectionState = newState;

            ConnectionStateChanged?.Invoke(sender,
                new ConnectionStateChangedEventArgs(oldState, newState));
        }

        private static void OnConnectionStateChanged(ConnectionStateChangedEventArgs e)
        {
            OnConnectionStateChanged(null, e);
        }
        private static void OnConnectionStateChanged(object sender, ConnectionStateChangedEventArgs e)
        {
            ConnectionStateChanged?.Invoke(sender, e);
        }

        internal static async Task<ApiResponse> ExecuteRequestJson(string request, object data,
            string token = null, RequestType type = RequestType.Post, ApiEndPoint endPoint = null)
        {
            var response = await ExecuteRequestJson<object>(request, data, token, type, endPoint)
                .ConfigureAwait(false);

            return new ApiResponse
            {
                code = response.code,
                error = response.error,
                message = response.message
            };
        }
        internal static async Task<ApiResponse<T>> ExecuteRequestJson<T>(string request, object data = null,
            string token = null, RequestType type = RequestType.Post, ApiEndPoint endPoint = null)
        {
            while (true)
            {
                try
                {
                    var httpRequest = new HttpRequestMessage();
                    HttpResponseMessage httpResponse;

                    httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(token))
                        httpRequest.Headers.Authorization = new AuthenticationHeaderValue(token);

                    if (endPoint == null)
                        endPoint = ApiEndPoint.GeneralPublic;

                    httpRequest.RequestUri = new Uri(endPoint.Url + request);

                    switch (type)
                    {
                        case RequestType.Get:
                        {
                            httpRequest.Method = HttpMethod.Get;
                            httpRequest.Content = null;

                            httpResponse = await HttpClient.SendAsync(httpRequest)
                                .ConfigureAwait(false);

                            break;
                        }
                        case RequestType.Post:
                        default:
                        {
                            StringContent content = null;

                            if (data != null)
                            {
                                var json = JsonConvert.SerializeObject(data);
                                content = new StringContent(json, Encoding.UTF8, "application/json");
                            }

                            httpRequest.Method = HttpMethod.Post;
                            httpRequest.Content = content;

                            httpResponse = await HttpClient.SendAsync(httpRequest)
                                .ConfigureAwait(false);

                            break;
                        }
                    }

                    var result = await httpResponse.Content.ReadAsStringAsync()
                        .ConfigureAwait(false);

                    OnConnectionStateChanged(ConnectionStateType.Connected);

                    //Pasha, I love you ( no :)))))))))))))))))))))))))))))))))))))))))))))))))))))))))))) )
                    //The best API in the world
                    try
                    {
                        return JsonConvert.DeserializeObject<ApiResponse<T>>(result);
                    }
                    catch (JsonSerializationException)
                    {
                        try
                        {
                            var response = JsonConvert.DeserializeObject<ApiResponse>(result);

                            return new ApiResponse<T>
                            {
                                code = response.code,
                                error = response.error,
                                data = default,
                                message = response.message
                            };
                        }
                        catch (JsonSerializationException)
                        {
                            return new ApiResponse<T>
                            {
                                code = 403,
                                error = true,
                                data = default,
                                message = "Forbidden beta. Pasha broke everything again"
                            };
                        }
                    }
                }
                catch (HttpRequestException)
                {
                    OnConnectionStateChanged(ConnectionStateType.Disconnected);

                    await Task.Delay(TimeSpan.FromSeconds(1))
                        .ConfigureAwait(false);
                }
            }
        }
    }
}
