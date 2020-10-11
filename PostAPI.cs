﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Memenim.Core.Data;

namespace Memenim.Core
{
    public static class PostAPI
    {
        public static async Task<ApiResponse<List<PostData>>> GetAllPosts(PostRequest data, string userToken)
        {
            return await APIHelper.RequestInternal<List<PostData>>("posts/get", data, userToken);
        }

        public static async Task<ApiResponse<List<PostData>>> GetPostById(int id, string userToken)
        {
            int[] ids = new int[1] { id };
            var requestData = new { post_ids = ids };
            return await APIHelper.RequestInternal<List<PostData>>("posts/getById", requestData, userToken);
        }

        public static async Task<ApiResponse<List<CommentData>>> GetCommentsForPost(int postId, int commentsOffset = 0)
        {
            var id = new { post_id = postId, offset = commentsOffset };
            return await APIHelper.RequestInternal<List<CommentData>>("posts/getComments", id);
        }

        public static async Task<ApiResponse<object>> SendComment(int postId, string content, bool? anonymous, string userToken)
        {
            var requestData = new { post_id = postId, text = content, anonim = Convert.ToInt32(anonymous) };
            return await APIHelper.RequestInternal<object>("posts/commentAdd", requestData, userToken);
        }

        public static async Task<ApiResponse<object>> SubmitPost(PostData post, string userToken)
        {
            return await APIHelper.RequestInternal<object>("posts/add", post, userToken);
        }

        public static async Task<ApiResponse<object>> EditPost(EditPostData postData, string userToken)
        {
            return await APIHelper.RequestInternal<object>("posts/edit", postData, userToken);
        }

        public static async Task<ApiResponse<object>> AddView(int postId,string userToken)
        {
            var requestData = new { post_id = postId };
            return await APIHelper.RequestInternal<object>("posts/viewAdd", requestData, userToken);
        }

        public static async Task<ApiResponse<object>> AddRepost(int postId, string userToken)
        {
            var requestData = new { post_id = postId };
            return await APIHelper.RequestInternal<object>("posts/repost", requestData, userToken);
        }

        public static async Task<ApiResponse<object>> LikePost(int postId, string userToken)
        {
            var requestData = new { post_id = postId };
            return await APIHelper.RequestInternal<object>("posts/likeAdd", requestData, userToken);
        }

        public static async Task<ApiResponse<object>> DislikePost(int postId, string userToken)
        {
            var requestData = new { post_id = postId };
            return await APIHelper.RequestInternal<object>("posts/dislikeAdd", requestData, userToken);
        }


        public static async Task<ApiResponse<object>> LikeComment(int commentId, string userToken)
        {
            var requestData = new { comment_id = commentId };
            return await APIHelper.RequestInternal<object>("posts/likeCommentAdd", requestData, userToken);
        }

        public static async Task<ApiResponse<object>> DislikeComment(int commentId, string userToken)
        {
            var requestData = new { comment_id = commentId };
            return await APIHelper.RequestInternal<object>("posts/dislikeCommentAdd", requestData, userToken);
        }

    }
}
