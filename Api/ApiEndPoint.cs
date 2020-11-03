using System;

namespace Memenim.Core.Api
{
    internal class ApiEndPoint
    {
        public static ApiEndPoint GeneralDev { get; }
        public static ApiEndPoint GeneralPublic { get; }
        public static ApiEndPoint GroupDev { get; }
        public static ApiEndPoint GroupPublic { get; }
        public static ApiEndPoint Chat { get; }
        public static ApiEndPoint Photo { get; }

        public string Name { get; }
        public string Url { get; }

        static ApiEndPoint()
        {
            GeneralDev = new ApiEndPoint(nameof(GeneralDev), "http://dev.apianon.ru:3000/");
            GeneralPublic = new ApiEndPoint(nameof(GeneralPublic), "http://public.apianon.ru:3000/");
            GroupDev = new ApiEndPoint(nameof(GroupDev), "http://dev.apianon.ru:8080/");
            GroupPublic = new ApiEndPoint(nameof(GroupPublic), "http://public.apianon.ru:8080/");
            Chat = new ApiEndPoint(nameof(Chat), "https://chat.apianon.ru/");
            Photo = new ApiEndPoint(nameof(Photo), "http://fotoanon.ru/");
        }

        private ApiEndPoint(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}
