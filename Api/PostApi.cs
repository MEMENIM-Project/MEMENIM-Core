using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Memenim.Core.Schema;

namespace Memenim.Core.Api
{
    public static class PostApi
    {
        public static Task<ApiResponse<List<PostSchema>>> Get(
            PostType type = PostType.Popular, int count = 20, int offset = 0)
        {
            var requestData = new
            {
                type,
                count,
                offset
            };

            return ApiRequestEngine.ExecuteRequestJson<List<PostSchema>>("posts/get", requestData);
        }
        public static Task<ApiResponse<List<PostSchema>>> Get(string token,
            PostType type = PostType.Popular, int count = 20, int offset = 0)
        {
            var requestData = new
            {
                type,
                count,
                offset
            };

            return ApiRequestEngine.ExecuteRequestJson<List<PostSchema>>("posts/get", requestData, token);
        }

        public static async Task<ApiResponse<PostSchema>> GetById(int id)
        {
            var requestData = new
            {
                post_ids = new[]
                {
                    id
                }
            };

            var response = await ApiRequestEngine.ExecuteRequestJson<List<PostSchema>>("posts/getById", requestData)
                .ConfigureAwait(false);

            return new ApiResponse<PostSchema>
            {
                code = response.code,
                data = response.data.Count != 0
                    ? response.data[0]
                    : null,
                error = response.error,
                message = response.message
            };
        }
        public static async Task<ApiResponse<PostSchema>> GetById(string token, int id)
        {
            var requestData = new
            {
                post_ids = new[]
                {
                    id
                }
            };

            var response = await ApiRequestEngine.ExecuteRequestJson<List<PostSchema>>("posts/getById", requestData, token)
                .ConfigureAwait(false);

            return new ApiResponse<PostSchema>
            {
                code = response.code,
                data = response.data.Count != 0
                    ? response.data[0]
                    : null,
                error = response.error,
                message = response.message
            };
        }
        public static Task<ApiResponse<List<PostSchema>>> GetById(int[] ids)
        {
            var requestData = new
            {
                post_ids = ids
            };

            return ApiRequestEngine.ExecuteRequestJson<List<PostSchema>>("posts/getById", requestData);
        }
        public static Task<ApiResponse<List<PostSchema>>> GetById(string token, int[] ids)
        {
            var requestData = new
            {
                post_ids = ids
            };

            return ApiRequestEngine.ExecuteRequestJson<List<PostSchema>>("posts/getById", requestData, token);
        }

        public static Task<ApiResponse<IdSchema>> Add(string token, PostSchema post)
        {
            return ApiRequestEngine.ExecuteRequestJson<IdSchema>("posts/add", post, token);
        }

        public static Task<ApiResponse> Remove(string token, int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson("posts/removePost", requestData, token);
        }

        public static Task<ApiResponse> Edit(string token, PostEditSchema schema)
        {
            return ApiRequestEngine.ExecuteRequestJson("posts/edit", schema, token);
        }

        public static Task<ApiResponse> AddView(int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson("posts/viewAdd", requestData);
        }
        public static Task<ApiResponse> AddView(string token, int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson("posts/viewAdd", requestData, token);
        }

        public static Task<ApiResponse> AddRepost(int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson("posts/repost", requestData);
        }
        public static Task<ApiResponse> AddRepost(string token, int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson("posts/repost", requestData, token);
        }

        public static Task<ApiResponse<CountSchema>> AddLike(string token, int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson<CountSchema>("posts/likeAdd", requestData, token);
        }

        public static Task<ApiResponse<CountSchema>> RemoveLike(string token, int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson<CountSchema>("posts/likeDelete", requestData, token);
        }

        public static Task<ApiResponse<CountSchema>> AddDislike(string token,  int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson<CountSchema>("posts/dislikeAdd", requestData, token);
        }

        public static Task<ApiResponse<CountSchema>> RemoveDislike(string token, int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson<CountSchema>("posts/dislikeDelete", requestData, token);
        }



        public static Task<ApiResponse<List<CommentSchema>>> GetComments(int postId, int count = 20, int offset = 0)
        {
            var requestData = new
            {
                post_id = postId,
                count,
                offset
            };

            return ApiRequestEngine.ExecuteRequestJson<List<CommentSchema>>("posts/getComments", requestData);
        }
        public static Task<ApiResponse<List<CommentSchema>>> GetComments(string token, int postId, int count = 20, int offset = 0)
        {
            var requestData = new
            {
                post_id = postId,
                count,
                offset
            };

            return ApiRequestEngine.ExecuteRequestJson<List<CommentSchema>>("posts/getComments", requestData, token);
        }

        public static Task<ApiResponse<IdSchema>> AddComment(string token, int postId, string text, bool? anonymous = false)
        {
            var requestData = new
            {
                post_id = postId,
                text,
                anonim = Convert.ToInt32(anonymous)
            };

            return ApiRequestEngine.ExecuteRequestJson<IdSchema>("posts/commentAdd", requestData, token);
        }

        public static Task<ApiResponse> RemoveComment(string token, int id)
        {
            var requestData = new
            {
                comment_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson("posts/removeComment", requestData, token);
        }

        public static Task<ApiResponse> EditComment(string token, int id, string text)
        {
            var requestData = new
            {
                comment_id = id,
                text
            };

            return ApiRequestEngine.ExecuteRequestJson("posts/editComment", requestData, token);
        }

        public static Task<ApiResponse<CountSchema>> AddLikeComment(string token, int id)
        {
            var requestData = new
            {
                comment_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson<CountSchema>("posts/likeCommentAdd", requestData, token);
        }

        public static Task<ApiResponse<CountSchema>> RemoveLikeComment(string token, int id)
        {
            var requestData = new
            {
                comment_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson<CountSchema>("posts/likeCommentDelete", requestData, token);
        }

        public static Task<ApiResponse<CountSchema>> AddDislikeComment(string token, int id)
        {
            var requestData = new
            {
                comment_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson<CountSchema>("posts/dislikeCommentAdd", requestData, token);
        }

        public static Task<ApiResponse<CountSchema>> RemoveDislikeComment(string token, int id)
        {
            var requestData = new
            {
                comment_id = id
            };

            return ApiRequestEngine.ExecuteRequestJson<CountSchema>("posts/dislikeCommentDelete", requestData, token);
        }
    }
}
