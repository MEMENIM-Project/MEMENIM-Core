using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace Memenim.Core.Schema
{
    public class ApiResponse : BaseSchema
    {
        private int _code;
        [JsonProperty("code")]
        public int Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                OnPropertyChanged(nameof(Code));
            }
        }
        private bool _isError;
        [JsonProperty("error")]
        public bool IsError
        {
            get
            {
                return _isError;
            }
            set
            {
                _isError = value;
                OnPropertyChanged(nameof(IsError));
            }
        }
        private string _message;
        [JsonProperty("message")]
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
    }
    public class ApiResponse<T> : BaseSchema
    {
        private int _code;
        [JsonProperty("code")]
        public int Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                OnPropertyChanged(nameof(Code));
            }
        }
        private bool _isError;
        [JsonProperty("error")]
        public bool IsError
        {
            get
            {
                return _isError;
            }
            set
            {
                _isError = value;
                OnPropertyChanged(nameof(IsError));
            }
        }
        private string _message;
        [JsonProperty("message")]
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        private T _data;
        [JsonProperty("data")]
        public T Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }
    }


    internal class RocketApiResponse : BaseSchema
    {
        private string _status;
        [JsonProperty("status")]
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        private string _error;
        [JsonProperty("error")]
        public string Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
            }
        }
        private string _message;
        [JsonProperty("message")]
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public ApiResponse GetApiResponse(HttpResponseMessage response)
        {
            var result = GetApiResponse();

            if (response != null)
                result.Code = (int)response.StatusCode;

            return result;
        }
        public ApiResponse GetApiResponse()
        {
            var result = new ApiResponse();

            RocketErrorStatus errorStatus = RocketErrorStatus.Error;

            if (Enum.TryParse<RocketErrorStatus>(
                Status, true, out var errorStatusObject))
            {
                errorStatus = errorStatusObject;
            }

            result.Code = 200;
            result.IsError = Convert.ToBoolean((byte)errorStatus);
            result.Message = Error ?? Message;

            return result;
        }
    }
    internal class RocketApiResponse<T> : BaseSchema
    {
        private string _status;
        [JsonProperty("status")]
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        private string _error;
        [JsonProperty("error")]
        public string Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
            }
        }
        private string _message;
        [JsonProperty("message")]
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        private T _data;
        [JsonProperty("data")]
        public T Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        public ApiResponse<T> GetApiResponse(HttpResponseMessage response)
        {
            var result = GetApiResponse();

            if (response != null)
                result.Code = (int)response.StatusCode;

            return result;
        }
        public ApiResponse<T> GetApiResponse()
        {
            var result = new ApiResponse<T>();

            RocketErrorStatus errorStatus = RocketErrorStatus.Error;

            if (Enum.TryParse<RocketErrorStatus>(
                Status, true, out var errorStatusObject))
            {
                errorStatus = errorStatusObject;
            }

            result.Code = 200;
            result.IsError = Convert.ToBoolean((byte)errorStatus);
            result.Message = Error ?? Message;
            result.Data = Data;

            return result;
        }
    }
}
