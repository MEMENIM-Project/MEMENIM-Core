using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Memenim.Core.Schema;

namespace Memenim.Core.Api
{
    public static class PostApi
    {
        public static ReadOnlyDictionary<int, PostCategorySchema> PostCategories { get; private set; }

        static PostApi()
        {
            ApiResponse<List<PostCategorySchema>> result;

            do
            {
                result = GetPostCategories().Result;
            } while (result?.IsError != false);

            var postCategories =
                new Dictionary<int, PostCategorySchema>(result.Data.Count);

            foreach (var postCategory in result.Data)
            {
                postCategories.Add(
                    postCategory.Id,
                    postCategory);
            }

            PostCategories =
                new ReadOnlyDictionary<int, PostCategorySchema>(postCategories);
        }

        public static Task<ApiResponse<List<PostSchema>>> Get(
            PostType type = PostType.Popular, int count = 20, int offset = 0)
        {
            var requestData = new
            {
                type,
                count,
                offset
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<List<PostSchema>>("posts/get", requestData);
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

            return ApiRequestEngine.ExecuteAnonymRequestJson<List<PostSchema>>("posts/get", requestData, token);
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

            var response = await ApiRequestEngine.ExecuteAnonymRequestJson<List<PostSchema>>("posts/getById", requestData)
                .ConfigureAwait(false);

            var data = response.Data != null && response.Data.Count != 0
                ? response.Data[0]
                : null;

            return new ApiResponse<PostSchema>
            {
                Code = response.Code,
                Data = data,
                IsError = response.IsError,
                Message = response.Message
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

            var response = await ApiRequestEngine.ExecuteAnonymRequestJson<List<PostSchema>>("posts/getById", requestData, token)
                .ConfigureAwait(false);

            var data = response.Data != null && response.Data.Count != 0
                ? response.Data[0]
                : null;

            return new ApiResponse<PostSchema>
            {
                Code = response.Code,
                Data = data,
                IsError = response.IsError,
                Message = response.Message
            };
        }
        public static Task<ApiResponse<List<PostSchema>>> GetById(int[] ids)
        {
            var requestData = new
            {
                post_ids = ids
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<List<PostSchema>>("posts/getById", requestData);
        }
        public static Task<ApiResponse<List<PostSchema>>> GetById(string token, int[] ids)
        {
            var requestData = new
            {
                post_ids = ids
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<List<PostSchema>>("posts/getById", requestData, token);
        }

        public static Task<ApiResponse<List<PostSchema>>> GetByUserId(
            int userId, int count = 20, int offset = 0)
        {
            var requestData = new
            {
                user_id = userId,
                count,
                offset
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<List<PostSchema>>("posts/getByUserId", requestData);
        }
        public static Task<ApiResponse<List<PostSchema>>> GetByUserId(string token,
            int userId, int count = 20, int offset = 0)
        {
            var requestData = new
            {
                user_id = userId,
                count,
                offset
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<List<PostSchema>>("posts/getByUserId", requestData, token);
        }

        public static Task<ApiResponse<IdSchema>> Add(string token, PostSchema post)
        {
            return ApiRequestEngine.ExecuteAnonymRequestJson<IdSchema>("posts/add", post, token);
        }

        public static Task<ApiResponse> Remove(string token, int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson("posts/removePost", requestData, token);
        }

        public static Task<ApiResponse> Edit(string token, PostEditSchema schema)
        {
            return ApiRequestEngine.ExecuteAnonymRequestJson("posts/edit", schema, token);
        }

        public static Task<ApiResponse> AddView(int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson("posts/viewAdd", requestData);
        }
        public static Task<ApiResponse> AddView(string token, int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson("posts/viewAdd", requestData, token);
        }

        public static Task<ApiResponse> AddRepost(int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson("posts/repost", requestData);
        }
        public static Task<ApiResponse> AddRepost(string token, int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson("posts/repost", requestData, token);
        }

        public static Task<ApiResponse<CountSchema>> AddLike(string token, int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<CountSchema>("posts/likeAdd", requestData, token);
        }

        public static Task<ApiResponse<CountSchema>> RemoveLike(string token, int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<CountSchema>("posts/likeDelete", requestData, token);
        }

        public static Task<ApiResponse<CountSchema>> AddDislike(string token,  int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<CountSchema>("posts/dislikeAdd", requestData, token);
        }

        public static Task<ApiResponse<CountSchema>> RemoveDislike(string token, int id)
        {
            var requestData = new
            {
                post_id = id
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<CountSchema>("posts/dislikeDelete", requestData, token);
        }

        public static Task<ApiResponse<List<PostCategorySchema>>> GetPostCategories()
        {
            var requestData = new
            {
                count = uint.MaxValue
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<List<PostCategorySchema>>("posts/getCategories", requestData);
        }



        public static Task<ApiResponse<List<CommentSchema>>> GetComments(int postId, int count = 20, int offset = 0)
        {
            var requestData = new
            {
                post_id = postId,
                count,
                offset
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<List<CommentSchema>>("posts/getComments", requestData);
        }
        public static Task<ApiResponse<List<CommentSchema>>> GetComments(string token, int postId, int count = 20, int offset = 0)
        {
            var requestData = new
            {
                post_id = postId,
                count,
                offset
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<List<CommentSchema>>("posts/getComments", requestData, token);
        }

        public static Task<ApiResponse<IdSchema>> AddComment(string token, int postId, string text, bool? anonymous = false)
        {
            var requestData = new
            {
                post_id = postId,
                text,
                anonim = Convert.ToInt32(anonymous)
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<IdSchema>("posts/commentAdd", requestData, token);
        }

        public static Task<ApiResponse> RemoveComment(string token, int id)
        {
            var requestData = new
            {
                comment_id = id
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson("posts/removeComment", requestData, token);
        }

        public static Task<ApiResponse> EditComment(string token, int id, string text)
        {
            var requestData = new
            {
                comment_id = id,
                text
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson("posts/editComment", requestData, token);
        }

        public static Task<ApiResponse<CountSchema>> AddLikeComment(string token, int id)
        {
            var requestData = new
            {
                comment_id = id
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<CountSchema>("posts/likeCommentAdd", requestData, token);
        }

        public static Task<ApiResponse<CountSchema>> RemoveLikeComment(string token, int id)
        {
            var requestData = new
            {
                comment_id = id
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<CountSchema>("posts/likeCommentDelete", requestData, token);
        }

        public static Task<ApiResponse<CountSchema>> AddDislikeComment(string token, int id)
        {
            var requestData = new
            {
                comment_id = id
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<CountSchema>("posts/dislikeCommentAdd", requestData, token);
        }

        public static Task<ApiResponse<CountSchema>> RemoveDislikeComment(string token, int id)
        {
            var requestData = new
            {
                comment_id = id
            };

            return ApiRequestEngine.ExecuteAnonymRequestJson<CountSchema>("posts/dislikeCommentDelete", requestData, token);
        }
    }
}
