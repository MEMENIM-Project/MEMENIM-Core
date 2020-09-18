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
        public static async Task<ApiResponse<List<PostData>>> GetAllPosts(PostRequest data, string userToken)
        {
            return await APIHelper.RequestInternal<List<PostData>>("posts/get", data, userToken);
        }

        public static async Task<ApiResponse<List<CommentData>>> GetCommentsForPost(int postId)
        {
            var id = new { post_id = postId };
            return await APIHelper.RequestInternal<List<CommentData>>("posts/getComments", id);
        }

        public static async Task<ApiResponse<object>> SendComment(int postId, string content, bool? anonymous, string userToken)
        {
            var requestData = new { post_id = postId, text = content, anonim = anonymous };
            return await APIHelper.RequestInternal<object>("posts/commentAdd", requestData, userToken);
        }

        public static async Task<ApiResponse<object>> SubmitPost(PostData post, string userToken)
        {
            return await APIHelper.RequestInternal<object>("posts/add", post, userToken);
        }

    }
}
