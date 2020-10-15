using System;
using System.Collections.Generic;

namespace Memenim.Core.Data
{
    //UserApi

    public class AuthData
    {
        public int id { get; set; }
        public string token { get; set; }
    }

    public class ProfileData
    {
        public int id { get; set; }
        public string login { get; set; }
        public string name { get; set; }
        public string think { get; set; }
        public int target { get; set; }
        public string dream { get; set; }
        public string hvalues { get; set; }
        public string interests { get; set; }
        public string fmusic { get; set; }
        public string ffilms { get; set; }
        public string fbooks { get; set; }
        public string about { get; set; }
        public string tempo { get; set; }
        public string attitude { get; set; }
        public int age { get; set; }
        public int sex { get; set; }
        public int country { get; set; }
        public string city { get; set; }
        public string photo { get; set; }
        public string banner { get; set; }
    }

    public class IdData
    {
        public int id { get; set; }
    }

    //PostApi

    public class RectangleData
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class PhotoSizeData
    {
        public RectangleData photo_small { get; set; }
        public RectangleData photo_medium { get; set; }
        public RectangleData photo_big { get; set; }
    }

    public class PhotoData
    {
        public string photo_big { get; set; }
        public string photo_medium { get; set; }
        public string photo_small { get; set; }
        public PhotoSizeData size { get; set; }
    }

    public class StatisticData
    {
        public int count { get; set; }
    }

    public class AttachmentData
    {
        public string link { get; set; } = null;
        public PhotoData photo { get; set; }
        public string type { get; set; } = "photo";
    }

    public class PostData
    {
        public int id { get; set; }
        public string text { get; set; }
        public string owner_name { get; set; }
        public int? owner_id { get; set; }
        public int adult { get; set; }
        public int open_comments { get; set; } = 1;
        public int category { get; set; } = 6;
        public int hidden { get; set; }
        public int filter { get; set; }
        public int type { get; set; } = 1;
        public long date { get; set; }
        public int author_watch { get; set; }
        public int reposts { get; set; }
        public StatisticData postviews { get; set; }
        public StatisticData likes { get; set; }
        public StatisticData dislikes { get; set; }
        public StatisticData comments { get; set; }
        public List<AttachmentData> attachments { get; set; }
    }



    public class CommentData
    {
        public class CommentUserData
        {
            public int id { get; set; }
            public string name { get; set; }
            public string photo { get; set; }
        }

        public int id { get; set; }
        public string text { get; set; }
        public CommentUserData user { get; set; }
    }

    //PhotoApi

    public class LibraryPhotoData
    {
        public int id { get; set; }
        public string photo_small { get; set; }
        public string photo_medium { get; set; }
        public string photo_big { get; set; }
    }
}
