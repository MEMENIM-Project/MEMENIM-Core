using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Memenim.Core.Data;
using Newtonsoft.Json;

namespace Memenim.Core.Api
{
    internal static class ApiRequestEngine
    {
#if NETCOREAPP
        private static readonly SocketsHttpHandler HttpHandler;
#elif NETSTANDARD
        private static readonly HttpClientHandler HttpHandler;
#endif
        private static readonly HttpClient HttpClient;
        private static readonly JsonSerializerSettings JsonSettings;

        static ApiRequestEngine()
        {
#if NETCOREAPP
            HttpHandler = new SocketsHttpHandler
            {
                MaxConnectionsPerServer = 1024
            };
#elif NETSTANDARD
            HttpHandler = new HttpClientHandler
            {
                MaxConnectionsPerServer = 1024
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
        }

        public static async Task<ApiResponse<T>> ExecuteRequestJson<T>(string request, object data,
            string token = null, RequestType type = RequestType.Post, ApiEndPoint endPoint = null)
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            HttpResponseMessage httpResponse;

            httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(token))
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue(token);

            if (endPoint == null)
                endPoint = ApiEndPoint.General;

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
                    string json = JsonConvert.SerializeObject(data);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    httpRequest.Method = HttpMethod.Post;
                    httpRequest.Content = content;

                    httpResponse = await HttpClient.SendAsync(httpRequest)
                        .ConfigureAwait(false);

                    break;
                }
            }

            string result = await httpResponse.Content.ReadAsStringAsync()
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<ApiResponse<T>>(result);
        }
    }
}
