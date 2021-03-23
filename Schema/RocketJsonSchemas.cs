using System;
using Newtonsoft.Json;

#pragma warning disable IDE0051 // Remove unused private member
#pragma warning disable RCS1213 // Remove unused member declaration.
namespace Memenim.Core.Schema
{
    //UserChatApi

    public class RocketProfileFieldsSchema : BaseSchema
    {
        private int? _anonymId;
        [JsonProperty("anonym_id")]
        public int? AnonymId
        {
            get
            {
                return _anonymId;
            }
            set
            {
                _anonymId = value;
                OnPropertyChanged(nameof(AnonymId));
            }
        }
        private string _anonymPhotoUrl;
        [JsonProperty("photoUrl")]
        public string AnonymPhotoUrl
        {
            get
            {
                return _anonymPhotoUrl;
            }
            set
            {
                _anonymPhotoUrl = value;
                OnPropertyChanged(nameof(AnonymPhotoUrl));
            }
        }
    }

    public class RocketProfileSchema : BaseSchema
    {
        private string _id;
        [JsonProperty("_id")]
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private string _nickname;
        [JsonProperty("name")]
        public string Nickname
        {
            get
            {
                return _nickname;
            }
            set
            {
                _nickname = value;
                OnPropertyChanged(nameof(Nickname));
            }
        }
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
        private string _login;
        [JsonProperty("username")]
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        private RocketProfileFieldsSchema _fields = new RocketProfileFieldsSchema();
        [JsonProperty("customFields")]
        public RocketProfileFieldsSchema Fields
        {
            get
            {
                return _fields;
            }
            set
            {
                _fields = value;
                OnPropertyChanged(nameof(Fields));
            }
        }
    }

    public class RocketAuthSchema : BaseSchema
    {
        private string _id;
        [JsonProperty("userId")]
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private string _token;
        [JsonProperty("authToken")]
        public string Token
        {
            get
            {
                return _token;
            }
            set
            {
                _token = value;
                OnPropertyChanged(nameof(Token));
            }
        }
        private RocketProfileSchema _profile = new RocketProfileSchema();
        [JsonProperty("me")]
        public RocketProfileSchema Profile
        {
            get
            {
                return _profile;
            }
            set
            {
                _profile = value;
                OnPropertyChanged(nameof(Profile));
            }
        }
    }
}
#pragma warning restore IDE0051 // Remove unused private member
#pragma warning restore RCS1213 // Remove unused member declaration.
