using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Memenim.Core.Data;

namespace Memenim.Core.Api
{
    public static class PostApi
    {
        public static Task<ApiResponse<List<PostData>>> GetAll(PostRequest data, string token)
        {
            return ApiRequestEngine.ExecuteRequestJson<List<PostData>>("posts/get", data, token);
        }

        public static Task<ApiResponse<List<PostData>>> GetById(int id, string token)
        {
            var requestData = new
            {
                post_ids = new int[] { id }
            };

            return ApiRequestEngine.ExecuteRequestJson<List<PostData>>("posts/getById", requestData, token);
        }

        public static Task<ApiResponse<object>> AddPost(PostData post, string token)
        {
            return ApiRequestEngine.ExecuteRequestJson<object>("posts/add", post, token);
        }

        public static Task<ApiResponse<object>> EditPost(EditPostRequest postData, string token)
        {
            return ApiRequestEngine.ExecuteRequestJson<object>("posts/edit", postData, token);
        }

        public static Task<ApiResponse<object>> AddView(int id, string token)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson<object>("posts/viewAdd", requestData, token);
        }

        public static Task<ApiResponse<object>> AddRepost(int id, string token)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson<object>("posts/repost", requestData, token);
        }

        public static Task<ApiResponse<object>> AddLike(int id, string token)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson<object>("posts/likeAdd", requestData, token);
        }

        public static Task<ApiResponse<object>> AddDislike(int id, string token)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson<object>("posts/dislikeAdd", requestData, token);
        }



        public static Task<ApiResponse<List<CommentData>>> GetComments(int id, int offset = 0)
        {
            var requestData = new
            {
                post_id = id,
                offset
            };

            return ApiRequestEngine.ExecuteRequestJson<List<CommentData>>("posts/getComments", requestData);
        }

        public static Task<ApiResponse<object>> AddComment(int id, string content, bool? anonymous, string token)
        {
            var requestData = new
            {
                post_id = id,
                text = content,
                anonim = Convert.ToInt32(anonymous)
            };

            return ApiRequestEngine.ExecuteRequestJson<object>("posts/commentAdd", requestData, token);
        }

        public static Task<ApiResponse<object>> AddLikeComment(int id, string token)
        {
            var requestData = new
            {
                comment_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson<object>("posts/likeCommentAdd", requestData, token);
        }

        public static Task<ApiResponse<object>> AddDislikeComment(int id, string token)
        {
            var requestData = new
            {
                comment_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson<object>("posts/dislikeCommentAdd", requestData, token);
        }

    }
}
