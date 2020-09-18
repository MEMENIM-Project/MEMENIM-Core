using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Memenim.Core.Data;

namespace Memenim.Core
{
    public static class UsersAPI
    {
        public static async Task<ApiResponse<AuthData>> RegisterUser(string username, string pass)
        {
            var auth = new { login = username, password = pass };
            return await APIHelper.RequestInternal<AuthData>("users/add", auth);
        }

        public static async Task<ApiResponse<AuthData>> Login(string username, string pass)
        {
            var auth = new { login = username, password = pass };
            return await APIHelper.RequestInternal<AuthData>("users/login2", auth);
        }

        public static async Task<ApiResponse<List<ProfileData>>> GetUserProfileByID(int profileId)
        {
            IDData data = new IDData() { id = profileId };
            return await APIHelper.RequestInternal<List<ProfileData>>("users/profile/getById", data);
        }

        public static async Task<ApiResponse<object>> EditProfile(ProfileData profileData, string userToken)
        {
            return await APIHelper.RequestInternal<object>("users/profile/set", profileData, userToken);
        }
    }
}
