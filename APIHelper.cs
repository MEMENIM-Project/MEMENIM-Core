using System;
using Memenim.Core.Data;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Memenim.Core
{
    struct APIEndPoints
    {
        public static string GENERAL_API_STRING = "http://dev.apianon.ru:3000/";
        public static string GROUP_API_STRING = "http://dev.apianon.ru:8080";
        public static string CHAT_API_STRING = "https://chat.apianon.ru";
        public static string PHOTO_API_STRING = "http://fotoanon.ru";
    }

    public enum ERequestType
    {
        GET,
        POST
    }


    static class APIHelper
    {
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// General solution to perform a generic request to service
        /// </summary>
        /// <typeparam name="T">Requested Data</typeparam>
        /// <param name="request">String of API request</param>
        /// <param name="requestData"></param>
        /// <returns>Returns a response data from service</returns>
        public static async Task<ApiResponse<T>> RequestInternal<T>(string request, object requestData, string token = "", ERequestType requestType = ERequestType.POST)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if(!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            }
            var json = JsonConvert.SerializeObject(requestData);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = new HttpResponseMessage();


            switch (requestType)
            {
                case ERequestType.GET:
                    response = await client.GetAsync(APIEndPoints.GENERAL_API_STRING + request);
                    break;
                case ERequestType.POST:
                default:
                    response = await client.PostAsync(APIEndPoints.GENERAL_API_STRING + request, data);
                    break;
            }

            string result = response.Content.ReadAsStringAsync().Result;
            ApiResponse<T> resp = JsonConvert.DeserializeObject<ApiResponse<T>>(result);
            return resp;
        }
        
    }
}
