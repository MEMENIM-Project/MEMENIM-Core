using System;

namespace Memenim.Core.Api
{
    internal class ApiEndPoint
    {
        public static ApiEndPoint General { get; }
        public static ApiEndPoint Group { get; }
        public static ApiEndPoint Chat { get; }
        public static ApiEndPoint Photo { get; }

        public string Name { get; }
        public string Url { get; }

        static ApiEndPoint()
        {
            General = new ApiEndPoint("General", "http://dev.apianon.ru:3000/");
            Group = new ApiEndPoint("Group", "http://dev.apianon.ru:8080/");
            Chat = new ApiEndPoint("Chat", "https://chat.apianon.ru/");
            Photo = new ApiEndPoint("Photo", "http://fotoanon.ru/");
        }

        private ApiEndPoint(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}
