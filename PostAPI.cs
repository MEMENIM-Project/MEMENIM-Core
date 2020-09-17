using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Memenim.Core.Data;

namespace Memenim.Core
{
    static class PostAPI
    {
        public static async Task<ApiResponse<List<PostData>>> GetAllPosts()
        {
            var res = await APIHelper.RequestInternal<List<PostData>>("posts/get", null);
            return res;
        }
    }
}
