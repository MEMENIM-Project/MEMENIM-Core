using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Memenim.Core.Data;

namespace Memenim.Core.Api
{
    public static class UserApi
    {
        public static Task<ApiResponse<AuthData>> Register(string username, string password)
        {
            var data = new
            {
                login = username,
                password
            };

            return ApiRequestEngine.ExecuteRequestJson<AuthData>("users/add", data);
        }

        public static Task<ApiResponse<AuthData>> Login(string username, string password)
        {
            var data = new
            {
                login = username,
                password
            };

            return ApiRequestEngine.ExecuteRequestJson<AuthData>("users/login2", data);
        }

        public static Task<ApiResponse<List<ProfileData>>> GetProfileById(int id)
        {
            IdData data = new IdData
            {
                id = id
            };

            return ApiRequestEngine.ExecuteRequestJson<List<ProfileData>>("users/profile/getById", data);
        }

        public static Task<ApiResponse<object>> EditProfile(ProfileData profileData, string token)
        {
            return ApiRequestEngine.ExecuteRequestJson<object>("users/profile/set", profileData, token);
        }
    }
}
