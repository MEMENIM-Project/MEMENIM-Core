using System;
using System.Threading.Tasks;
using Memenim.Core.Api;
using Memenim.Core.Schema;

namespace Memenim.Core.ChatApi
{
    public static class UserChatApi
    {
        public static Task<ApiResponse<RocketAuthSchema>> RocketLogin(string login, string password)
        {
            var requestData = new
            {
                login,
                password
            };

            return ApiRequestEngine.ExecuteRocketRequestJson<RocketAuthSchema>("login",
                requestData, null, null, RequestType.Post, ApiEndPoint.Chat);
        }
    }
}
