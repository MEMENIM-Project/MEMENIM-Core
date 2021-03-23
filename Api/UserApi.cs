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

            return ApiRequestEngine.ExecuteAnonymRequestJson<AuthSchema>("users/add", requestData);
        }

        public static Task<ApiResponse<AuthSchema>> Login(string login,
            string password)
        {
            var requestData = new
            {
                login,
                password
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<AuthSchema>("users/login2", requestData);
        }

        public static Task<ApiResponse> ChangePassword(string token,
            string oldPassword, string newPassword)
        {
            var requestData = new
            {
                oldPassword,
                newPassword
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson("users/changePassword", requestData, token);
        }

        public static async Task<ApiResponse<int?>> GetId(string token)
        {
            var response = await ApiRequestEngine.ExecuteAnonymRequestJson<IdSchema>("users/profile/get", null, token)
                .ConfigureAwait(false);

            return new ApiResponse<int?>
            {
                Code = response.Code,
                Data = response.Data?.Id,
                IsError = response.IsError,
                Message = response.Message
            };
        }

        public static Task<ApiResponse<List<SearchedUserSchema>>> GetUsers(int count = 20,
            int offset = 0, int type = 0)
        {
            var requestData = new
            {
                type,
                count,
                offset
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<List<SearchedUserSchema>>("users/get", requestData);
        }

        public static async Task<ApiResponse<UserSchema>> GetUser(string token)
        {
            ApiResponse<int?> idResponse = await GetId(token)
                .ConfigureAwait(false);

            if (idResponse.IsError || !idResponse.Data.HasValue)
            {
                return new ApiResponse<UserSchema>
                {
                    Code = idResponse.Code,
                    Data = null,
                    IsError = true,
                    Message = string.IsNullOrEmpty(idResponse.Message)
                        ? "user id is not valid"
                        : idResponse.Message
                };
            }

            return await GetUserById(idResponse.Data.Value)
                .ConfigureAwait(false);
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

            var response = await ApiRequestEngine.ExecuteAnonymRequestJson<List<UserSchema>>("users/getById", requestData)
                .ConfigureAwait(false);

            var data = response.Data != null && response.Data.Count != 0
                ? response.Data[0]
                : null;

            return new ApiResponse<UserSchema>
            {
                Code = response.Code,
                Data = data,
                IsError = response.IsError,
                Message = response.Message
            };
        }
        public static Task<ApiResponse<List<UserSchema>>> GetUserById(int[] ids)
        {
            var requestData = new
            {
                user_id = ids
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<List<UserSchema>>("users/getById", requestData);
        }

        public static async Task<ApiResponse<ProfileSchema>> GetProfile(string token)
        {
            ApiResponse<int?> idResponse = await GetId(token)
                .ConfigureAwait(false);

            if (idResponse.IsError || !idResponse.Data.HasValue)
            {
                return new ApiResponse<ProfileSchema>
                {
                    Code = idResponse.Code,
                    Data = null,
                    IsError = true,
                    Message = string.IsNullOrEmpty(idResponse.Message)
                        ? "user id is not valid"
                        : idResponse.Message
                };
            }

            return await GetProfileById(idResponse.Data.Value)
                .ConfigureAwait(false);
        }

        public static async Task<ApiResponse<ProfileSchema>> GetProfileById(int id)
        {
            var requestData = new IdSchema
            {
                Id = id
            };

            var response = await ApiRequestEngine.ExecuteAnonymRequestJson<List<ProfileSchema>>("users/profile/getById", requestData)
                .ConfigureAwait(false);

            var data = response.Data != null && response.Data.Count != 0
                ? response.Data[0]
                : null;

            return new ApiResponse<ProfileSchema>
            {
                Code = response.Code,
                Data = data,
                IsError = response.IsError,
                Message = response.Message
            };
        }

        public static Task<ApiResponse> EditProfile(string token, ProfileSchema profileData)
        {
            return ApiRequestEngine.ExecuteAnonymRequestJson("users/profile/set", profileData, token);
        }

        public static Task<ApiResponse<RocketPasswordSchema>> GetRocketPassword(string token)
        {
            return ApiRequestEngine.ExecuteAnonymRequestJson<RocketPasswordSchema>("users/getRocketPassword", null, token);
        }
    }
}
