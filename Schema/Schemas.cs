using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Memenim.Core.Api;
using Newtonsoft.Json;

#pragma warning disable IDE0051 // Remove unused private member
#pragma warning disable RCS1213 // Remove unused member declaration.
namespace Memenim.Core.Schema
{
    //UserApi

    public class IdSchema : BaseSchema
    {
        private int _id = -1;
        [JsonProperty("id")]
        public int Id
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
    }

    public class RocketPasswordSchema : BaseSchema
    {
        private string _password = string.Empty;
        [JsonProperty("password")]
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
    }

    public class AuthSchema : BaseSchema
    {
        private int _id = -1;
        [JsonProperty("id")]
        public int Id
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
        [JsonProperty("token")]
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
    }

    public class UserSchema : BaseSchema
    {
        private int _id = -1;
        [JsonProperty("id")]
        public int Id
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

        private string _login = string.Empty;
        [JsonProperty("login")]
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

        private string _nickname = string.Empty;
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

        private int _isOnlineOriginal;
        [JsonProperty("online")]
        private int IsOnlineOriginal
        {
            get
            {
                return _isOnlineOriginal;
            }
            set
            {
                _isOnlineOriginal = value;
                OnPropertyChanged(nameof(IsOnline));
            }
        }
        [JsonIgnore]
        public bool IsOnline
        {
            get
            {
                return _isOnlineOriginal != 0;
            }
            set
            {
                _isOnlineOriginal = Convert.ToInt32(value);
                OnPropertyChanged(nameof(IsOnline));
            }
        }
    }

    public class SearchedUserSchema : BaseSchema
    {
        private int _id = -1;
        [JsonProperty("id")]
        public int Id
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

        private string _nickname = string.Empty;
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

        private string _thoughts = string.Empty;
        [JsonProperty("think")]
        public string Thoughts
        {
            get
            {
                return _thoughts;
            }
            set
            {
                _thoughts = value;
                OnPropertyChanged(nameof(Thoughts));
            }
        }

        private string _dream = string.Empty;
        [JsonProperty("dream")]
        public string Dream
        {
            get
            {
                return _dream;
            }
            set
            {
                _dream = value;
                OnPropertyChanged(nameof(Dream));
            }
        }

        private string _about = string.Empty;
        [JsonProperty("about")]
        public string About
        {
            get
            {
                return _about;
            }
            set
            {
                _about = value;
                OnPropertyChanged(nameof(About));
            }
        }

        private int _age;
        [JsonProperty("age")]
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        private int _sexOriginal;
        [JsonProperty("sex")]
        private int SexOriginal
        {
            get
            {
                return _sexOriginal;
            }
            set
            {
                _sexOriginal = value;
                OnPropertyChanged(nameof(Sex));
            }
        }
        [JsonIgnore]
        public UserSexType Sex
        {
            get
            {
                return Enum.IsDefined(typeof(UserSexType), (byte)_sexOriginal)
                    ? (UserSexType)_sexOriginal
                    : UserSexType.Unknown;
            }
            set
            {
                _sexOriginal = (byte)value;
                OnPropertyChanged(nameof(Sex));
            }
        }

        private int _country;
        [JsonProperty("country")]
        public int Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                OnPropertyChanged(nameof(Country));
            }
        }

        private string _city = string.Empty;
        [JsonProperty("city")]
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        private string _photoUrl = string.Empty;
        [JsonProperty("photo")]
        public string PhotoUrl
        {
            get
            {
                return _photoUrl;
            }
            set
            {
                _photoUrl = value;
                OnPropertyChanged(nameof(PhotoUrl));
            }
        }

        private string _bannerUrl = string.Empty;
        [JsonProperty("banner")]
        public string BannerUrl
        {
            get
            {
                return _bannerUrl;
            }
            set
            {
                _bannerUrl = value;
                OnPropertyChanged(nameof(BannerUrl));
            }
        }

        private int _isOnlineOriginal;
        [JsonProperty("online")]
        private int IsOnlineOriginal
        {
            get
            {
                return _isOnlineOriginal;
            }
            set
            {
                _isOnlineOriginal = value;
                OnPropertyChanged(nameof(IsOnline));
            }
        }
        [JsonIgnore]
        public bool IsOnline
        {
            get
            {
                return _isOnlineOriginal != 0;
            }
            set
            {
                _isOnlineOriginal = Convert.ToInt32(value);
                OnPropertyChanged(nameof(IsOnline));
            }
        }
    }

    public class ProfileSchema : BaseSchema
    {
        private int _id = -1;
        [JsonProperty("id")]
        public int Id
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

        private string _login = string.Empty;
        [JsonProperty("login")]
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

        private string _nickname = string.Empty;
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

        private string _thoughts;
        [JsonProperty("think")]
        public string Thoughts
        {
            get
            {
                return _thoughts;
            }
            set
            {
                _thoughts = value;
                OnPropertyChanged(nameof(Thoughts));
            }
        }

        private int _purposeOriginal;
        [JsonProperty("target")]
        private int PurposeOriginal
        {
            get
            {
                return _purposeOriginal;
            }
            set
            {
                _purposeOriginal = value;
                OnPropertyChanged(nameof(Purpose));
            }
        }
        [JsonIgnore]
        public UserPurposeType Purpose
        {
            get
            {
                return Enum.IsDefined(typeof(UserPurposeType), (byte)_purposeOriginal)
                    ? (UserPurposeType)_purposeOriginal
                    : UserPurposeType.Unknown;
            }
            set
            {
                _purposeOriginal = (byte)value;
                OnPropertyChanged(nameof(Purpose));
            }
        }

        private string _dream;
        [JsonProperty("dream")]
        public string Dream
        {
            get
            {
                return _dream;
            }
            set
            {
                _dream = value;
                OnPropertyChanged(nameof(Dream));
            }
        }

        private string _about;
        [JsonProperty("about")]
        public string About
        {
            get
            {
                return _about;
            }
            set
            {
                _about = value;
                OnPropertyChanged(nameof(About));
            }
        }

        private string _values;
        [JsonProperty("hvalues")]
        public string Values
        {
            get
            {
                return _values;
            }
            set
            {
                _values = value;
                OnPropertyChanged(nameof(Values));
            }
        }

        private string _interests;
        [JsonProperty("interests")]
        public string Interests
        {
            get
            {
                return _interests;
            }
            set
            {
                _interests = value;
                OnPropertyChanged(nameof(Interests));
            }
        }

        private string _favoriteMusic;
        [JsonProperty("fmusic")]
        public string FavoriteMusic
        {
            get
            {
                return _favoriteMusic;
            }
            set
            {
                _favoriteMusic = value;
                OnPropertyChanged(nameof(FavoriteMusic));
            }
        }

        private string _favoriteBooks;
        [JsonProperty("fbooks")]
        public string FavoriteBooks
        {
            get
            {
                return _favoriteBooks;
            }
            set
            {
                _favoriteBooks = value;
                OnPropertyChanged(nameof(FavoriteBooks));
            }
        }

        private string _favoriteMovies;
        [JsonProperty("ffilms")]
        public string FavoriteMovies
        {
            get
            {
                return _favoriteMovies;
            }
            set
            {
                _favoriteMovies = value;
                OnPropertyChanged(nameof(FavoriteMovies));
            }
        }

        private string _emotionalPortrait;
        [JsonProperty("tempo")]
        public string EmotionalPortrait
        {
            get
            {
                return _emotionalPortrait;
            }
            set
            {
                _emotionalPortrait = value;
                OnPropertyChanged(nameof(EmotionalPortrait));
            }
        }

        private string _attitudeToOthers;
        [JsonProperty("attitude")]
        public string AttitudeToOthers
        {
            get
            {
                return _attitudeToOthers;
            }
            set
            {
                _attitudeToOthers = value;
                OnPropertyChanged(nameof(AttitudeToOthers));
            }
        }

        private int _age;
        [JsonProperty("age")]
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        private int _sexOriginal;
        [JsonProperty("sex")]
        private int SexOriginal
        {
            get
            {
                return _sexOriginal;
            }
            set
            {
                _sexOriginal = value;
                OnPropertyChanged(nameof(Sex));
            }
        }
        [JsonIgnore]
        public UserSexType Sex
        {
            get
            {
                return Enum.IsDefined(typeof(UserSexType), (byte)_sexOriginal)
                    ? (UserSexType)_sexOriginal
                    : UserSexType.Unknown;
            }
            set
            {
                _sexOriginal = (byte)value;
                OnPropertyChanged(nameof(Sex));
            }
        }

        private int _country;
        [JsonProperty("country")]
        public int Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                OnPropertyChanged(nameof(Country));
            }
        }

        private string _city;
        [JsonProperty("city")]
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        private string _photoUrl = string.Empty;
        [JsonProperty("photo")]
        public string PhotoUrl
        {
            get
            {
                return _photoUrl;
            }
            set
            {
                _photoUrl = value;
                OnPropertyChanged(nameof(PhotoUrl));
            }
        }

        private string _bannerUrl = string.Empty;
        [JsonProperty("banner")]
        public string BannerUrl
        {
            get
            {
                return _bannerUrl;
            }
            set
            {
                _bannerUrl = value;
                OnPropertyChanged(nameof(BannerUrl));
            }
        }

        private int _statusOriginal;
        [JsonProperty("status")]
        private int StatusOriginal
        {
            get
            {
                return _statusOriginal;
            }
            set
            {
                _statusOriginal = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        [JsonIgnore]
        public UserStatusType Status
        {
            get
            {
                return Enum.IsDefined(typeof(UserStatusType), (byte)_statusOriginal)
                    ? (UserStatusType)_statusOriginal
                    : UserStatusType.Active;
            }
            set
            {
                _statusOriginal = (byte)value;
                OnPropertyChanged(nameof(Status));
            }
        }
    }

    //PostApi

    public class PostCategorySchema : BaseSchema
    {
        private int _id = -1;
        [JsonProperty("id")]
        public int Id
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

        private string _name;
        [JsonProperty("text")]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }

    public class RectangleSchema : BaseSchema
    {
        private int _width;
        [JsonProperty("width")]
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        private int _height;
        [JsonProperty("height")]
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }
    }

    public class PhotoSizeSchema : BaseSchema
    {
        private RectangleSchema _small = new RectangleSchema();
        [JsonProperty("photo_small")]
        public RectangleSchema Small
        {
            get
            {
                return _small;
            }
            set
            {
                _small = value;
                OnPropertyChanged(nameof(Small));
            }
        }

        private RectangleSchema _medium = new RectangleSchema();
        [JsonProperty("photo_medium")]
        public RectangleSchema Medium
        {
            get
            {
                return _medium;
            }
            set
            {
                _medium = value;
                OnPropertyChanged(nameof(Medium));
            }
        }

        private RectangleSchema _big = new RectangleSchema();
        [JsonProperty("photo_big")]
        public RectangleSchema Big
        {
            get
            {
                return _big;
            }
            set
            {
                _big = value;
                OnPropertyChanged(nameof(Big));
            }
        }
    }

    public class PhotoSchema : BaseSchema
    {
        private string _smallUrl = string.Empty;
        [JsonProperty("photo_small")]
        public string SmallUrl
        {
            get
            {
                return _smallUrl;
            }
            set
            {
                _smallUrl = value;
                OnPropertyChanged(nameof(SmallUrl));
            }
        }

        private string _mediumUrl = string.Empty;
        [JsonProperty("photo_medium")]
        public string MediumUrl
        {
            get
            {
                return _mediumUrl;
            }
            set
            {
                _mediumUrl = value;
                OnPropertyChanged(nameof(MediumUrl));
            }
        }

        private string _bigUrl = string.Empty;
        [JsonProperty("photo_big")]
        public string BigUrl
        {
            get
            {
                return _bigUrl;
            }
            set
            {
                _bigUrl = value;
                OnPropertyChanged(nameof(BigUrl));
            }
        }

        private PhotoSizeSchema _size = new PhotoSizeSchema();
        [JsonProperty("size")]
        public PhotoSizeSchema Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                OnPropertyChanged(nameof(Size));
            }
        }
    }

    public class StatisticSchema : BaseSchema
    {
        private int _totalCount;
        [JsonProperty("count")]
        public int TotalCount
        {
            get
            {
                return _totalCount;
            }
            set
            {
                _totalCount = value;
                OnPropertyChanged(nameof(TotalCount));
            }
        }

        private int _myCount;
        [JsonProperty("my")]
        public int MyCount
        {
            get
            {
                return _myCount;
            }
            set
            {
                _myCount = value;
                OnPropertyChanged(nameof(MyCount));
            }
        }
    }

    public class AttachmentSchema : BaseSchema
    {
        private string _url;
        [JsonProperty("link")]
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
                OnPropertyChanged(nameof(Url));
            }
        }

        private string _type = "photo";
        [JsonProperty("type")]
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        private PhotoSchema _photo = new PhotoSchema();
        [JsonProperty("photo")]
        public PhotoSchema Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                _photo = value;
                OnPropertyChanged(nameof(Photo));
            }
        }
    }

    public class PostEditSchema : BaseSchema
    {
        private int _id = -1;
        [JsonProperty("id")]
        public int Id
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

        private string _text = string.Empty;
        [JsonProperty("text")]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        private int _categoryId = PostApi.PostCategories?.Values.FirstOrDefault()?.Id ?? 0;
        [JsonProperty("category")]
        public int CategoryId
        {
            get
            {
                return _categoryId;
            }
            set
            {
                _categoryId = value;
                OnPropertyChanged(nameof(CategoryId));
                OnPropertyChanged(nameof(CategoryName));
            }
        }

        //private string _categoryName = PostApi.PostCategories?.Values.FirstOrDefault()?.Name;
        [JsonProperty("category_string")]
        public string CategoryName
        {
            get
            {
                return PostApi.PostCategories.TryGetValue(
                    CategoryId, out var postCategory)
                    ? postCategory.Name
                    : null;
            }
            set
            {
                //_categoryName = value;
                OnPropertyChanged(nameof(CategoryName));
            }
        }

        private int _isAnonymousOriginal = 1;
        [JsonProperty("author_watch")]
        private string IsAnonymousOriginal
        {
            get
            {
                return _isAnonymousOriginal.ToString();
            }
            set
            {
                _isAnonymousOriginal = Convert.ToInt32(value);
                OnPropertyChanged(nameof(IsAnonymous));
            }
        }
        [JsonIgnore]
        public bool IsAnonymous
        {
            get
            {
                return (_isAnonymousOriginal - 1) == 0;
            }
            set
            {
                _isAnonymousOriginal = Convert.ToInt32(!value) + 1;
                OnPropertyChanged(nameof(IsAnonymous));
            }
        }

        private int _isCommentsOpenOriginal = 1;
        [JsonProperty("open_comments")]
        private int IsCommentsOpenOriginal
        {
            get
            {
                return _isCommentsOpenOriginal;
            }
            set
            {
                _isCommentsOpenOriginal = value;
                OnPropertyChanged(nameof(IsCommentsOpen));
            }
        }
        [JsonIgnore]
        public bool IsCommentsOpen
        {
            get
            {
                return _isCommentsOpenOriginal != 0;
            }
            set
            {
                _isCommentsOpenOriginal = Convert.ToInt32(value);
                OnPropertyChanged(nameof(IsCommentsOpen));
            }
        }

        private int _isHiddenOriginal;
        [JsonProperty("hidden")]
        private int IsHiddenOriginal
        {
            get
            {
                return _isHiddenOriginal;
            }
            set
            {
                _isHiddenOriginal = value;
                OnPropertyChanged(nameof(IsHidden));
            }
        }
        [JsonIgnore]
        public bool IsHidden
        {
            get
            {
                return _isHiddenOriginal != 0;
            }
            set
            {
                _isHiddenOriginal = Convert.ToInt32(value);
                OnPropertyChanged(nameof(IsHidden));
            }
        }

        private int _isAdultOriginal;
        [JsonProperty("adult")]
        private int IsAdultOriginal
        {
            get
            {
                return _isAdultOriginal;
            }
            set
            {
                _isAdultOriginal = value;
                OnPropertyChanged(nameof(IsAdult));
            }
        }
        [JsonIgnore]
        public bool IsAdult
        {
            get
            {
                return _isAdultOriginal != 0;
            }
            set
            {
                _isAdultOriginal = Convert.ToInt32(value);
                OnPropertyChanged(nameof(IsAdult));
            }
        }

        private int _filter;
        [JsonProperty("filter")]
        public int Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;
                OnPropertyChanged(nameof(Filter));
            }
        }

        private int _type = 1;
        [JsonProperty("type")]
        public int Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
    }

    public class PostSchema : BaseSchema
    {
        private int _id = -1;
        [JsonProperty("id")]
        public int Id
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

        private string _text = string.Empty;
        [JsonProperty("text")]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        private int? _ownerId;
        [JsonProperty("owner_id")]
        public int? OwnerId
        {
            get
            {
                return _ownerId;
            }
            set
            {
                _ownerId = value;
                OnPropertyChanged(nameof(OwnerId));
            }
        }

        private string _ownerNickname = string.Empty;
        [JsonProperty("owner_name")]
        public string OwnerNickname
        {
            get
            {
                return _ownerNickname;
            }
            set
            {
                _ownerNickname = value;
                OnPropertyChanged(nameof(OwnerNickname));
            }
        }

        private string _ownerPhotoUrl = string.Empty;
        [JsonProperty("owner_photo")]
        public string OwnerPhotoUrl
        {
            get
            {
                return _ownerPhotoUrl;
            }
            set
            {
                _ownerPhotoUrl = value;
                OnPropertyChanged(nameof(OwnerPhotoUrl));
            }
        }

        private int _categoryId = PostApi.PostCategories?.Values.FirstOrDefault()?.Id ?? 0;
        [JsonProperty("category")]
        public int CategoryId
        {
            get
            {
                return _categoryId;
            }
            set
            {
                _categoryId = value;
                OnPropertyChanged(nameof(CategoryId));
                OnPropertyChanged(nameof(CategoryName));
            }
        }

        //private string _categoryName = PostApi.PostCategories?.Values.FirstOrDefault()?.Name;
        [JsonProperty("category_string")]
        public string CategoryName
        {
            get
            {
                return PostApi.PostCategories.TryGetValue(
                    CategoryId, out var postCategory)
                    ? postCategory.Name
                    : null;
            }
            set
            {
                //_categoryName = value;
                OnPropertyChanged(nameof(CategoryName));
            }
        }

        private string _categoryTitle;
        [JsonProperty("category_title")]
        public string CategoryTitle
        {
            get
            {
                return _categoryTitle;
            }
            set
            {
                _categoryTitle = value;
                OnPropertyChanged(nameof(CategoryTitle));
            }
        }

        private int _isAnonymousOriginal = 1;
        [JsonProperty("author_watch")]
        private int IsAnonymousOriginal
        {
            get
            {
                return _isAnonymousOriginal;
            }
            set
            {
                _isAnonymousOriginal = value;
                OnPropertyChanged(nameof(IsAnonymous));
            }
        }
        [JsonIgnore]
        public bool IsAnonymous
        {
            get
            {
                return (_isAnonymousOriginal - 1) == 0;
            }
            set
            {
                _isAnonymousOriginal = Convert.ToInt32(!value) + 1;
                OnPropertyChanged(nameof(IsAnonymous));
            }
        }

        private int _isCommentsOpenOriginal = 1;
        [JsonProperty("open_comments")]
        private int IsCommentsOpenOriginal
        {
            get
            {
                return _isCommentsOpenOriginal;
            }
            set
            {
                _isCommentsOpenOriginal = value;
                OnPropertyChanged(nameof(IsCommentsOpen));
            }
        }
        [JsonIgnore]
        public bool IsCommentsOpen
        {
            get
            {
                return _isCommentsOpenOriginal != 0;
            }
            set
            {
                _isCommentsOpenOriginal = Convert.ToInt32(value);
                OnPropertyChanged(nameof(IsCommentsOpen));
            }
        }

        private int _isHiddenOriginal;
        [JsonProperty("hidden")]
        private int IsHiddenOriginal
        {
            get
            {
                return _isHiddenOriginal;
            }
            set
            {
                _isHiddenOriginal = value;
                OnPropertyChanged(nameof(IsHidden));
            }
        }
        [JsonIgnore]
        public bool IsHidden
        {
            get
            {
                return _isHiddenOriginal != 0;
            }
            set
            {
                _isHiddenOriginal = Convert.ToInt32(value);
                OnPropertyChanged(nameof(IsHidden));
            }
        }

        private int _isAdultOriginal;
        [JsonProperty("adult")]
        private int IsAdultOriginal
        {
            get
            {
                return _isAdultOriginal;
            }
            set
            {
                _isAdultOriginal = value;
                OnPropertyChanged(nameof(IsAdult));
            }
        }
        [JsonIgnore]
        public bool IsAdult
        {
            get
            {
                return _isAdultOriginal != 0;
            }
            set
            {
                _isAdultOriginal = Convert.ToInt32(value);
                OnPropertyChanged(nameof(IsAdult));
            }
        }

        private int _filter;
        [JsonProperty("filter")]
        public int Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;
                OnPropertyChanged(nameof(Filter));
            }
        }

        private int _type = 1;
        [JsonProperty("type")]
        public int Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        private long _utcDate;
        [JsonProperty("date")]
        public long UtcDate
        {
            get
            {
                return _utcDate;
            }
            set
            {
                _utcDate = value;
                OnPropertyChanged(nameof(UtcDate));
            }
        }

        private int _statusOriginal;
        [JsonProperty("status")]
        private int StatusOriginal
        {
            get
            {
                return _statusOriginal;
            }
            set
            {
                _statusOriginal = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        [JsonIgnore]
        public PostStatusType Status
        {
            get
            {
                return Enum.IsDefined(typeof(PostStatusType), (byte)_statusOriginal)
                    ? (PostStatusType)_statusOriginal
                    : PostStatusType.Published;
            }
            set
            {
                _statusOriginal = (byte)value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private int _shares;
        [JsonProperty("reposts")]
        public int Shares
        {
            get
            {
                return _shares;
            }
            set
            {
                _shares = value;
                OnPropertyChanged(nameof(Shares));
            }
        }

        private StatisticSchema _views = new StatisticSchema();
        [JsonProperty("postviews")]
        public StatisticSchema Views
        {
            get
            {
                return _views;
            }
            set
            {
                _views = value;
                OnPropertyChanged(nameof(Views));
            }
        }

        private StatisticSchema _likes = new StatisticSchema();
        [JsonProperty("likes")]
        public StatisticSchema Likes
        {
            get
            {
                return _likes;
            }
            set
            {
                _likes = value;
                OnPropertyChanged(nameof(Likes));
            }
        }

        private StatisticSchema _dislikes = new StatisticSchema();
        [JsonProperty("dislikes")]
        public StatisticSchema Dislikes
        {
            get
            {
                return _dislikes;
            }
            set
            {
                _dislikes = value;
                OnPropertyChanged(nameof(Dislikes));
            }
        }

        private StatisticSchema _comments = new StatisticSchema();
        [JsonProperty("comments")]
        public StatisticSchema Comments
        {
            get
            {
                return _comments;
            }
            set
            {
                _comments = value;
                OnPropertyChanged(nameof(Comments));
            }
        }

        private List<string> _tags = new List<string>();
        [JsonProperty("tags")]
        public List<string> Tags
        {
            get
            {
                return _tags;
            }
            set
            {
                _tags = value;
                OnPropertyChanged(nameof(Tags));
            }
        }

        private ObservableCollection<AttachmentSchema> _attachments =
            new ObservableCollection<AttachmentSchema>
            {
                new AttachmentSchema()
            };
        [JsonProperty("attachments")]
        public ObservableCollection<AttachmentSchema> Attachments
        {
            get
            {
                return _attachments;
            }
            set
            {
                if (_attachments != null)
                    _attachments.CollectionChanged -= OnAttachmentsChanged;

                _attachments = value;
                OnPropertyChanged(nameof(Attachments));


                if (_attachments != null)
                    _attachments.CollectionChanged += OnAttachmentsChanged;
            }
        }



        public PostSchema()
        {
            if (Attachments != null)
                Attachments.CollectionChanged += OnAttachmentsChanged;
        }

        private void OnAttachmentsChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (Attachments.Count > 1
                && args.Action == NotifyCollectionChangedAction.Add)
            {
                Attachments.RemoveAt(0);
            }
        }
    }



    public class CountSchema : BaseSchema
    {
        private int _count;
        [JsonProperty("count")]
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }
    }

    public class CommentUserSchema : BaseSchema
    {
        private int? _id = -1;
        [JsonProperty("id")]
        public int? Id
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

        private string _nickname = string.Empty;
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

        private string _photoUrl = string.Empty;
        [JsonProperty("photo")]
        public string PhotoUrl
        {
            get
            {
                return _photoUrl;
            }
            set
            {
                _photoUrl = value;
                OnPropertyChanged(nameof(PhotoUrl));
            }
        }
    }

    public class CommentSchema : BaseSchema
    {
        private int _id = -1;
        [JsonProperty("id")]
        public int Id
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

        private string _text = string.Empty;
        [JsonProperty("text")]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        private int _isAnonymousOriginal;
        [JsonProperty("anonim")]
        private int IsAnonymousOriginal
        {
            get
            {
                return _isAnonymousOriginal;
            }
            set
            {
                _isAnonymousOriginal = value;
                OnPropertyChanged(nameof(IsAnonymous));
            }
        }
        [JsonIgnore]
        public bool IsAnonymous
        {
            get
            {
                return _isAnonymousOriginal != 0;
            }
            set
            {
                _isAnonymousOriginal = Convert.ToInt32(value);
                OnPropertyChanged(nameof(IsAnonymous));
            }
        }

        private long _utcDate;
        [JsonProperty("date")]
        public long UtcDate
        {
            get
            {
                return _utcDate;
            }
            set
            {
                _utcDate = value;
                OnPropertyChanged(nameof(UtcDate));
            }
        }

        private CommentUserSchema _user = new CommentUserSchema();
        [JsonProperty("user")]
        public CommentUserSchema User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private StatisticSchema _likes = new StatisticSchema();
        [JsonProperty("likes")]
        public StatisticSchema Likes
        {
            get
            {
                return _likes;
            }
            set
            {
                _likes = value;
                OnPropertyChanged(nameof(Likes));
            }
        }

        private StatisticSchema _dislikes = new StatisticSchema();
        [JsonProperty("dislikes")]
        public StatisticSchema Dislikes
        {
            get
            {
                return _dislikes;
            }
            set
            {
                _dislikes = value;
                OnPropertyChanged(nameof(Dislikes));
            }
        }
    }

    //PhotoApi

    public class LibraryPhotoSchema : BaseSchema
    {
        private int _id = -1;
        [JsonProperty("id")]
        public int Id
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

        private string _smallUrl = string.Empty;
        [JsonProperty("photo_small")]
        public string SmallUrl
        {
            get
            {
                return _smallUrl;
            }
            set
            {
                _smallUrl = value;
                OnPropertyChanged(nameof(SmallUrl));
            }
        }

        private string _mediumUrl = string.Empty;
        [JsonProperty("photo_medium")]
        public string MediumUrl
        {
            get
            {
                return _mediumUrl;
            }
            set
            {
                _mediumUrl = value;
                OnPropertyChanged(nameof(MediumUrl));
            }
        }

        private string _bigUrl = string.Empty;
        [JsonProperty("photo_big")]
        public string BigUrl
        {
            get
            {
                return _bigUrl;
            }
            set
            {
                _bigUrl = value;
                OnPropertyChanged(nameof(BigUrl));
            }
        }
    }
}
#pragma warning restore IDE0051 // Remove unused private member
#pragma warning restore RCS1213 // Remove unused member declaration.
