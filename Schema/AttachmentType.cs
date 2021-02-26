using System;

namespace Memenim.Core.Schema
{
    public class AttachmentType
    {
        public static AttachmentType Unknown { get; }
        public static AttachmentType Link { get; }
        public static AttachmentType Photo { get; }

        public string Name { get; }
        public string OriginalName { get; }

        static AttachmentType()
        {
            Unknown = new AttachmentType(nameof(Photo), "unknown");
            Link = new AttachmentType(nameof(Link), "link");
            Photo = new AttachmentType(nameof(Photo), "photo");
        }

        private AttachmentType(string name, string originalName)
        {
            Name = name;
            OriginalName = originalName;
        }

        public static AttachmentType Parse(string originalName)
        {
            switch (originalName)
            {
                case "link":
                    return Link;
                case "photo":
                    return Photo;
                case "unknown":
                default:
                    return Unknown;
            }
        }

        public override string ToString()
        {
            return OriginalName;
        }
    }
}
