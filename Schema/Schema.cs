using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Memenim.Core.Schema
{
    //UserApi

    public class IdSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _id = -1;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(id));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class AuthSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _id = -1;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(id));
            }
        }
        private string _token;
        public string token
        {
            get
            {
                return _token;
            }
            set
            {
                _token = value;
                OnPropertyChanged(nameof(token));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class UserSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _id = -1;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(id));
            }
        }
        private string _login = string.Empty;
        public string login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(login));
            }
        }
        private string _name = string.Empty;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(name));
            }
        }
        private int _online = -1;
        public int online
        {
            get
            {
                return _online;
            }
            set
            {
                _online = value;
                OnPropertyChanged(nameof(online));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class SearchedUserSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _id = -1;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(id));
            }
        }
        private string _name = string.Empty;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(name));
            }
        }
        private string _think = string.Empty;
        public string think
        {
            get
            {
                return _think;
            }
            set
            {
                _think = value;
                OnPropertyChanged(nameof(think));
            }
        }
        private string _dream = string.Empty;
        public string dream
        {
            get
            {
                return _dream;
            }
            set
            {
                _dream = value;
                OnPropertyChanged(nameof(dream));
            }
        }
        private string _about = string.Empty;
        public string about
        {
            get
            {
                return _about;
            }
            set
            {
                _about = value;
                OnPropertyChanged(nameof(about));
            }
        }
        private int _age;
        public int age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(age));
            }
        }
        private int _sex;
        public int sex
        {
            get
            {
                return _sex;
            }
            set
            {
                _sex = value;
                OnPropertyChanged(nameof(sex));
            }
        }
        private int _country;
        public int country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                OnPropertyChanged(nameof(country));
            }
        }
        private string _city = string.Empty;
        public string city
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(city));
            }
        }
        private string _photo = string.Empty;
        public string photo
        {
            get
            {
                return _photo;
            }
            set
            {
                _photo = value;
                OnPropertyChanged(nameof(photo));
            }
        }
        private string _banner = string.Empty;
        public string banner
        {
            get
            {
                return _banner;
            }
            set
            {
                _banner = value;
                OnPropertyChanged(nameof(banner));
            }
        }
        private int _online = -1;
        public int online
        {
            get
            {
                return _online;
            }
            set
            {
                _online = value;
                OnPropertyChanged(nameof(online));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ProfileSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _id = -1;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(id));
            }
        }
        private string _login = string.Empty;
        public string login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(login));
            }
        }
        private string _name = string.Empty;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(name));
            }
        }
        private string _think;
        public string think
        {
            get
            {
                return _think;
            }
            set
            {
                _think = value;
                OnPropertyChanged(nameof(think));
            }
        }
        private int _target;
        public int target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
                OnPropertyChanged(nameof(target));
            }
        }
        private string _dream;
        public string dream
        {
            get
            {
                return _dream;
            }
            set
            {
                _dream = value;
                OnPropertyChanged(nameof(dream));
            }
        }
        private string _about;
        public string about
        {
            get
            {
                return _about;
            }
            set
            {
                _about = value;
                OnPropertyChanged(nameof(about));
            }
        }
        private string _hvalues;
        public string hvalues
        {
            get
            {
                return _hvalues;
            }
            set
            {
                _hvalues = value;
                OnPropertyChanged(nameof(hvalues));
            }
        }
        private string _interests;
        public string interests
        {
            get
            {
                return _interests;
            }
            set
            {
                _interests = value;
                OnPropertyChanged(nameof(interests));
            }
        }
        private string _fmusic;
        public string fmusic
        {
            get
            {
                return _fmusic;
            }
            set
            {
                _fmusic = value;
                OnPropertyChanged(nameof(fmusic));
            }
        }
        private string _ffilms;
        public string ffilms
        {
            get
            {
                return _ffilms;
            }
            set
            {
                _ffilms = value;
                OnPropertyChanged(nameof(ffilms));
            }
        }
        private string _fbooks;
        public string fbooks
        {
            get
            {
                return _fbooks;
            }
            set
            {
                _fbooks = value;
                OnPropertyChanged(nameof(fbooks));
            }
        }
        private string _tempo;
        public string tempo
        {
            get
            {
                return _tempo;
            }
            set
            {
                _tempo = value;
                OnPropertyChanged(nameof(tempo));
            }
        }
        private string _attitude;
        public string attitude
        {
            get
            {
                return _attitude;
            }
            set
            {
                _attitude = value;
                OnPropertyChanged(nameof(attitude));
            }
        }
        private int _age;
        public int age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(age));
            }
        }
        private int _sex;
        public int sex
        {
            get
            {
                return _sex;
            }
            set
            {
                _sex = value;
                OnPropertyChanged(nameof(sex));
            }
        }
        private int _country;
        public int country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                OnPropertyChanged(nameof(country));
            }
        }
        private string _city;
        public string city
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(city));
            }
        }
        private string _photo = string.Empty;
        public string photo
        {
            get
            {
                return _photo;
            }
            set
            {
                _photo = value;
                OnPropertyChanged(nameof(photo));
            }
        }
        private string _banner = string.Empty;
        public string banner
        {
            get
            {
                return _banner;
            }
            set
            {
                _banner = value;
                OnPropertyChanged(nameof(banner));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    //PostApi

    public class RectangleSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _width;
        public int width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                OnPropertyChanged(nameof(width));
            }
        }
        private int _height;
        public int height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                OnPropertyChanged(nameof(height));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PhotoSizeSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private RectangleSchema _photo_small = new RectangleSchema();
        public RectangleSchema photo_small
        {
            get
            {
                return _photo_small;
            }
            set
            {
                _photo_small = value;
                OnPropertyChanged(nameof(photo_small));
            }
        }
        private RectangleSchema _photo_medium = new RectangleSchema();
        public RectangleSchema photo_medium
        {
            get
            {
                return _photo_medium;
            }
            set
            {
                _photo_medium = value;
                OnPropertyChanged(nameof(photo_medium));
            }
        }
        private RectangleSchema _photo_big = new RectangleSchema();
        public RectangleSchema photo_big
        {
            get
            {
                return _photo_big;
            }
            set
            {
                _photo_big = value;
                OnPropertyChanged(nameof(photo_big));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PhotoSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _photo_small = string.Empty;
        public string photo_small
        {
            get
            {
                return _photo_small;
            }
            set
            {
                _photo_small = value;
                OnPropertyChanged(nameof(photo_small));
            }
        }
        private string _photo_medium = string.Empty;
        public string photo_medium
        {
            get
            {
                return _photo_medium;
            }
            set
            {
                _photo_medium = value;
                OnPropertyChanged(nameof(photo_medium));
            }
        }
        private string _photo_big = string.Empty;
        public string photo_big
        {
            get
            {
                return _photo_big;
            }
            set
            {
                _photo_big = value;
                OnPropertyChanged(nameof(photo_big));
            }
        }
        private PhotoSizeSchema _size = new PhotoSizeSchema();
        public PhotoSizeSchema size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                OnPropertyChanged(nameof(size));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class StatisticSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _count;
        public int count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                OnPropertyChanged(nameof(count));
            }
        }
        private int _my;
        public int my
        {
            get
            {
                return _my;
            }
            set
            {
                _my = value;
                OnPropertyChanged(nameof(my));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class AttachmentSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _link;
        public string link
        {
            get
            {
                return _link;
            }
            set
            {
                _link = value;
                OnPropertyChanged(nameof(link));
            }
        }
        private PhotoSchema _photo = new PhotoSchema();
        public PhotoSchema photo
        {
            get
            {
                return _photo;
            }
            set
            {
                _photo = value;
                OnPropertyChanged(nameof(photo));
            }
        }
        private string _type = "photo";
        public string type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(type));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PostEditSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _id = -1;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(id));
            }
        }
        private string _text = string.Empty;
        public string text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(text));
            }
        }
        private int _adult;
        public int adult
        {
            get
            {
                return _adult;
            }
            set
            {
                _adult = value;
                OnPropertyChanged(nameof(adult));
            }
        }
        private int _open_comments = 1;
        public int open_comments
        {
            get
            {
                return _open_comments;
            }
            set
            {
                _open_comments = value;
                OnPropertyChanged(nameof(open_comments));
            }
        }
        private int _category = 6;
        public int category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                OnPropertyChanged(nameof(category));
            }
        }
        private int _hidden;
        public int hidden
        {
            get
            {
                return _hidden;
            }
            set
            {
                _hidden = value;
                OnPropertyChanged(nameof(hidden));
            }
        }
        private int _filter;
        public int filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;
                OnPropertyChanged(nameof(filter));
            }
        }
        private int _type = 1;
        public int type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(type));
            }
        }
        private int _author_watch = 1;
        public string author_watch
        {
            get
            {
                return _author_watch.ToString();
            }
            set
            {
                _author_watch = Convert.ToInt32(value);
                OnPropertyChanged(nameof(author_watch));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PostSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PostSchema()
        {
            attachments.CollectionChanged += (sender, args) =>
            {
                if (attachments.Count > 1 && args.Action == NotifyCollectionChangedAction.Add)
                    attachments.RemoveAt(0);
            };
        }

        private int _id = -1;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(id));
            }
        }
        private string _text = string.Empty;
        public string text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(text));
            }
        }
        private int? _owner_id;
        public int? owner_id
        {
            get
            {
                return _owner_id;
            }
            set
            {
                _owner_id = value;
                OnPropertyChanged(nameof(owner_id));
            }
        }
        private string _owner_name = string.Empty;
        public string owner_name
        {
            get
            {
                return _owner_name;
            }
            set
            {
                _owner_name = value;
                OnPropertyChanged(nameof(owner_name));
            }
        }
        private string _owner_photo = string.Empty;
        public string owner_photo
        {
            get
            {
                return _owner_photo;
            }
            set
            {
                _owner_photo = value;
                OnPropertyChanged(nameof(owner_photo));
            }
        }
        private int _adult;
        public int adult
        {
            get
            {
                return _adult;
            }
            set
            {
                _adult = value;
                OnPropertyChanged(nameof(adult));
            }
        }
        private int _open_comments = 1;
        public int open_comments
        {
            get
            {
                return _open_comments;
            }
            set
            {
                _open_comments = value;
                OnPropertyChanged(nameof(open_comments));
            }
        }
        private int _category = 6;
        public int category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                OnPropertyChanged(nameof(category));
            }
        }
        private int _hidden;
        public int hidden
        {
            get
            {
                return _hidden;
            }
            set
            {
                _hidden = value;
                OnPropertyChanged(nameof(hidden));
            }
        }
        private int _filter;
        public int filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;
                OnPropertyChanged(nameof(filter));
            }
        }
        private int _type = 1;
        public int type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(type));
            }
        }
        private long _date;
        public long date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(date));
            }
        }
        private int _author_watch = 1;
        public int author_watch
        {
            get
            {
                return _author_watch;
            }
            set
            {
                _author_watch = value;
                OnPropertyChanged(nameof(author_watch));
            }
        }
        private int _reposts;
        public int reposts
        {
            get
            {
                return _reposts;
            }
            set
            {
                _reposts = value;
                OnPropertyChanged(nameof(reposts));
            }
        }
        private StatisticSchema _postviews = new StatisticSchema();
        public StatisticSchema postviews
        {
            get
            {
                return _postviews;
            }
            set
            {
                _postviews = value;
                OnPropertyChanged(nameof(postviews));
            }
        }
        private StatisticSchema _likes = new StatisticSchema();
        public StatisticSchema likes
        {
            get
            {
                return _likes;
            }
            set
            {
                _likes = value;
                OnPropertyChanged(nameof(likes));
            }
        }
        private StatisticSchema _dislikes = new StatisticSchema();
        public StatisticSchema dislikes
        {
            get
            {
                return _dislikes;
            }
            set
            {
                _dislikes = value;
                OnPropertyChanged(nameof(dislikes));
            }
        }
        private StatisticSchema _comments = new StatisticSchema();
        public StatisticSchema comments
        {
            get
            {
                return _comments;
            }
            set
            {
                _comments = value;
                OnPropertyChanged(nameof(comments));
            }
        }
        private ObservableCollection<AttachmentSchema> _attachments =
            new ObservableCollection<AttachmentSchema>
            {
                new AttachmentSchema()
            };
        public ObservableCollection<AttachmentSchema> attachments
        {
            get
            {
                return _attachments;
            }
            set
            {
                _attachments = value;
                OnPropertyChanged(nameof(attachments));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



    public class CountSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _count;
        public int count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                OnPropertyChanged(nameof(count));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CommentUserSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _id = -1;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(id));
            }
        }
        private string _name = string.Empty;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(name));
            }
        }
        private string _photo = string.Empty;
        public string photo
        {
            get
            {
                return _photo;
            }
            set
            {
                _photo = value;
                OnPropertyChanged(nameof(photo));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CommentSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _id = -1;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(id));
            }
        }
        private string _text = string.Empty;
        public string text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(text));
            }
        }
        private int _anonim;
        public int anonim
        {
            get
            {
                return _anonim;
            }
            set
            {
                _anonim = value;
                OnPropertyChanged(nameof(anonim));
            }
        }
        private long _date;
        public long date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(date));
            }
        }
        private CommentUserSchema _user = new CommentUserSchema();
        public CommentUserSchema user
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(user));
            }
        }
        private StatisticSchema _likes = new StatisticSchema();
        public StatisticSchema likes
        {
            get
            {
                return _likes;
            }
            set
            {
                _likes = value;
                OnPropertyChanged(nameof(likes));
            }
        }
        private StatisticSchema _dislikes = new StatisticSchema();
        public StatisticSchema dislikes
        {
            get
            {
                return _dislikes;
            }
            set
            {
                _dislikes = value;
                OnPropertyChanged(nameof(dislikes));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    //PhotoApi

    public class LibraryPhotoSchema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _id = -1;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(id));
            }
        }
        private string _photo_small = string.Empty;
        public string photo_small
        {
            get
            {
                return _photo_small;
            }
            set
            {
                _photo_small = value;
                OnPropertyChanged(nameof(photo_small));
            }
        }
        private string _photo_medium = string.Empty;
        public string photo_medium
        {
            get
            {
                return _photo_medium;
            }
            set
            {
                _photo_medium = value;
                OnPropertyChanged(nameof(photo_medium));
            }
        }
        private string _photo_big = string.Empty;
        public string photo_big
        {
            get
            {
                return _photo_big;
            }
            set
            {
                _photo_big = value;
                OnPropertyChanged(nameof(photo_big));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
