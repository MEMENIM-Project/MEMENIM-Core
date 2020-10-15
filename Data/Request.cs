using System;

namespace Memenim.Core.Data
{
    public class PostRequest
    {
        public int count { get; set; } = 20;
        public int offset { get; set; } = 0;
        public PostType type { get; set; } = PostType.Popular;
    }

    public class EditPostRequest
    {
        public int id { get; set; }
        public string text { get; set; }
    }
}
