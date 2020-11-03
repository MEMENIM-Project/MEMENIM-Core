using System;

namespace Memenim.Core.Schema
{
    public class ApiResponse
    {
        public int code { get; set; }
        public bool error { get; set; }
        public string message { get; set; }
    }
    public class ApiResponse<T>
    {
        public int code { get; set; }
        public bool error { get; set; }
        public T data { get; set; }
        public string message { get; set; }
    }
}
