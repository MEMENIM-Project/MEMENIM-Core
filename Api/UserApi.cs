using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Memenim.Core.Schema;

namespace Memenim.Core.Api
{
    public static class UserApi
    {
        public static Task<ApiResponse<AuthSchema>> Register(string login,
            string password, string nickname = null)
        {
            if (nickname == null)
                nickname = login;

            var requestData = new
            {
                login,
                password,
                name = nickname
            };

            return ApiRequestEngine.ExecuteRequestJson<AuthSchema>("users/add", requestData);
        }

        public static Task<ApiResponse> ChangePassword(string token,
            string oldPassword, string newPassword)
        {
            var requestData = new
            {
                oldPassword,
                newPassword
            };

            return ApiRequestEngine.ExecuteRequestJson("users/changePassword", requestData, token);
        }

        public static Task<ApiResponse<AuthSchema>> Login(string login, string password)
        {
            var requestData = new
            {
                login,
                password
            };

            return ApiRequestEngine.ExecuteRequestJson<AuthSchema>("users/login2", requestData);
        }

        public static Task<ApiResponse<List<SearchedUserSchema>>> GetUsers(int count = 20, int offset = 0, int type = 0)
        {
            var requestData = new
            {
                type,
                count,
                offset
            };

            return ApiRequestEngine.ExecuteRequestJson<List<SearchedUserSchema>>("users/get", requestData);
        }

        public static async Task<ApiResponse<UserSchema>> GetUserById(int id)
        {
            var requestData = new
            {
                user_id = new[]
                {
                    id
                }
            };

            var response = await ApiRequestEngine.ExecuteRequestJson<List<UserSchema>>("users/getById", requestData)
                .ConfigureAwait(false);

            return new ApiResponse<UserSchema>
            {
                code = response.code,
                data = response.data.Count != 0
                    ? response.data[0]
                    : null,
                error = response.error,
                message = response.message
            };
        }
        public static Task<ApiResponse<List<UserSchema>>> GetUserById(int[] ids)
        {
            var requestData = new
            {
                user_id = ids
            };

            return ApiRequestEngine.ExecuteRequestJson<List<UserSchema>>("users/getById", requestData);
        }

        public static async Task<ApiResponse<ProfileSchema>> GetProfileById(int id)
        {
            var requestData = new IdSchema
            {
                id = id
            };

            var response = await ApiRequestEngine.ExecuteRequestJson<List<ProfileSchema>>("users/profile/getById", requestData)
                .ConfigureAwait(false);

            return new ApiResponse<ProfileSchema>
            {
                code = response.code,
                data = response.data.Count != 0
                    ? response.data[0]
                    : null,
                error = response.error,
                message = response.message
            };
        }

        public static Task<ApiResponse> EditProfile(string token, ProfileSchema profileData)
        {
            return ApiRequestEngine.ExecuteRequestJson("users/profile/set", profileData, token);
        }
    }
}
