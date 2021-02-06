﻿using System;
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
        public static event EventHandler<CoreInformationEventArgs> Information;
        public static event EventHandler<CoreWarningEventArgs> Warning;
        public static event EventHandler<CoreErrorEventArgs> Error;

        public static event EventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged;

        private static readonly Random RandomGenerator;
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
            RandomGenerator = new Random(Environment.TickCount);

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

        public static void OnInformation(CoreInformationEventArgs e)
        {
            OnInformation(null, e);
        }
        public static void OnInformation(object sender, CoreInformationEventArgs e)
        {
            Information?.Invoke(sender, e);
        }

        public static void OnWarning(CoreWarningEventArgs e)
        {
            OnWarning(null, e);
        }
        public static void OnWarning(object sender, CoreWarningEventArgs e)
        {
            Warning?.Invoke(sender, e);
        }

        public static void OnError(CoreErrorEventArgs e)
        {
            OnError(null, e);
        }
        public static void OnError(object sender, CoreErrorEventArgs e)
        {
            Error?.Invoke(sender, e);
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
                Code = response.Code,
                IsError = response.IsError,
                Message = response.Message
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
                    string jsonData = string.Empty;

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
                                jsonData = JsonConvert.SerializeObject(data);
                                content = new StringContent(jsonData, Encoding.UTF8, "application/json");
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

                    int resultCode;

                    try
                    {
                        resultCode = (int)httpResponse.StatusCode;
                    }
                    catch (Exception)
                    {
                        resultCode = -1;
                    }

                    try
                    {
                        var resultResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(result);

                        OnConnectionStateChanged(ConnectionStateType.Connected);

                        OnInformation(null, new CoreInformationEventArgs(
                            $"Request[Uri={httpRequest?.RequestUri?.ToString() ?? "Unknown"}, Content={jsonData ?? "Unknown"}] response success. " +
                            $"\nCode={resultCode}"));

                        return resultResponse;
                    }
                    catch (JsonSerializationException ex)
                    {
                        try
                        {
                            var resultResponse = JsonConvert.DeserializeObject<ApiResponse>(result);

                            OnConnectionStateChanged(ConnectionStateType.Connected);

                            OnError(null, new CoreErrorEventArgs(
                                ex,
                                $"Request[Uri={httpRequest?.RequestUri?.ToString() ?? "Unknown"}, Content={jsonData ?? "Unknown"}] response serialization error. " +
                                $"\nCode={resultCode}, Response=\n{result ?? "Unknown"}\n",
                                ex.StackTrace));

                            return new ApiResponse<T>
                            {
                                Code = resultResponse.Code,
                                IsError = resultResponse.IsError,
                                Data = default,
                                Message = resultResponse.Message
                            };
                        }
                        catch (JsonSerializationException ex2)
                        {
                            OnConnectionStateChanged(ConnectionStateType.Connected);

                            OnError(null, new CoreErrorEventArgs(
                                ex2,
                                $"Request[Uri={httpRequest?.RequestUri?.ToString() ?? "Unknown"}, Content={jsonData ?? "Unknown"}] response serialization error. " +
                                $"\nCode={resultCode}, Response=\n{result ?? "Unknown"}\n",
                                ex2.StackTrace));

                            return new ApiResponse<T>
                            {
                                Code = resultCode,
                                IsError = true,
                                Data = default,
                                Message = "Forbidden beta. Pasha Lyubin broke everything again"
                            };
                        }
                        catch (JsonReaderException ex2)
                            when (resultCode == 429)
                        {
                            OnError(null, new CoreErrorEventArgs(
                                ex2,
                                $"Request[Uri={httpRequest?.RequestUri?.ToString() ?? "Unknown"}, Content={jsonData ?? "Unknown"}] rejected (too many requests). " +
                                $"\nCode={resultCode}",
                                ex2.StackTrace));

                            await Task.Delay(TimeSpan.FromMilliseconds(
                                    RandomGenerator.Next(300, 1500)))
                                .ConfigureAwait(false);
                        }
                        catch (JsonReaderException ex2)
                        {
                            OnConnectionStateChanged(ConnectionStateType.Disconnected);

                            OnError(null, new CoreErrorEventArgs(
                                ex2,
                                $"Request[Uri={httpRequest?.RequestUri?.ToString() ?? "Unknown"}, Content={jsonData ?? "Unknown"}] response read error. " +
                                $"\nCode={resultCode}, Response=\n{result ?? "Unknown"}\n",
                                ex2.StackTrace));

                            await Task.Delay(TimeSpan.FromSeconds(3))
                                .ConfigureAwait(false);
                        }
                    }
                    catch (JsonReaderException ex)
                        when (resultCode == 429)
                    {
                        OnError(null, new CoreErrorEventArgs(
                            ex,
                            $"Request[Uri={httpRequest?.RequestUri?.ToString() ?? "Unknown"}, Content={jsonData ?? "Unknown"}] rejected (too many requests). " +
                            $"\nCode={resultCode}",
                            ex.StackTrace));

                        await Task.Delay(TimeSpan.FromMilliseconds(
                                RandomGenerator.Next(300, 1500)))
                            .ConfigureAwait(false);
                    }
                    catch (JsonReaderException ex)
                    {
                        OnConnectionStateChanged(ConnectionStateType.Disconnected);

                        OnError(null, new CoreErrorEventArgs(
                            ex,
                            $"Request[Uri={httpRequest?.RequestUri?.ToString() ?? "Unknown"}, Content={jsonData ?? "Unknown"}] response read error. " +
                            $"\nCode={resultCode}, Response=\n{result ?? "Unknown"}\n",
                            ex.StackTrace));

                        await Task.Delay(TimeSpan.FromSeconds(3))
                            .ConfigureAwait(false);
                    }
                }
                catch (HttpRequestException ex)
                {
                    OnConnectionStateChanged(ConnectionStateType.Disconnected);

                    OnError(null, new CoreErrorEventArgs(
                        ex,
                        $"Request[Uri={(endPoint == null ? ApiEndPoint.GeneralPublic.Url : endPoint.Url) + request}] " +
                        "sending error.",
                        ex.StackTrace));

                    await Task.Delay(TimeSpan.FromSeconds(1))
                        .ConfigureAwait(false);
                }
            }
        }
    }
}
