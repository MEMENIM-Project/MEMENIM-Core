using System;
using Newtonsoft.Json;

namespace Memenim.Core.Schema
{
    public class ApiResponse : BaseSchema
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("error")]
        public bool IsError { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
    public class ApiResponse<T> : BaseSchema
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("error")]
        public bool IsError { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
