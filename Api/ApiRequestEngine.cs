using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
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

        private static int _connectionState;
        public static ConnectionStateType ConnectionState
        {
            get
            {
                return (ConnectionStateType)_connectionState;
            }
            private set
            {
                Interlocked.Exchange(ref _connectionState, (int)value);
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

            ConnectionState = ConnectionStateType.Connected;
        }

        public static void OnConnectionStateChanged(ConnectionStateType newState)
        {
            OnConnectionStateChanged(null, newState);
        }
        public static void OnConnectionStateChanged(object sender, ConnectionStateType newState)
        {
            var oldState = Interlocked.Exchange(ref _connectionState, (int)newState);

            if (oldState == (int)newState)
                return;

            ConnectionStateChanged?.Invoke(sender,
                new ConnectionStateChangedEventArgs((ConnectionStateType)oldState, newState));
        }

        private static void OnConnectionStateChanged(ConnectionStateChangedEventArgs e)
        {
            OnConnectionStateChanged(null, e);
        }
        private static void OnConnectionStateChanged(object sender, ConnectionStateChangedEventArgs e)
        {
            ConnectionStateChanged?.Invoke(sender, e);
        }

        internal static async Task<ApiResponse> ExecuteRequestJson(string request, object data = null,
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

                    //Pasha Lyubin, I love you ( no :)))))))))))))))))))))))))))))))))))))))))))))))))))))))))))) )
                    //The best API in the world
                    try
                    {
                        var resultResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(result);

                        OnConnectionStateChanged(ConnectionStateType.Connected);

                        return resultResponse;
                    }
                    catch (JsonSerializationException)
                    {
                        try
                        {
                            var resultResponse = JsonConvert.DeserializeObject<ApiResponse>(result);

                            OnConnectionStateChanged(ConnectionStateType.Connected);

                            return new ApiResponse<T>
                            {
                                code = resultResponse.code,
                                error = resultResponse.error,
                                data = default,
                                message = resultResponse.message
                            };
                        }
                        catch (JsonSerializationException)
                        {
                            OnConnectionStateChanged(ConnectionStateType.Connected);

                            return new ApiResponse<T>
                            {
                                code = (int)httpResponse.StatusCode,
                                error = true,
                                data = default,
                                message = "Forbidden beta. Pasha Lyubin broke everything again"
                            };
                        }
                        catch (JsonReaderException)
                        {
                            OnConnectionStateChanged(ConnectionStateType.Disconnected);

                            await Task.Delay(TimeSpan.FromSeconds(3))
                                .ConfigureAwait(false);
                        }
                    }
                    catch (JsonReaderException)
                    {
                        OnConnectionStateChanged(ConnectionStateType.Disconnected);

                        await Task.Delay(TimeSpan.FromSeconds(3))
                            .ConfigureAwait(false);
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
