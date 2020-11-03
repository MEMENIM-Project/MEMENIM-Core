using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Memenim.Core.Schema;

namespace Memenim.Core.Api
{
    public static class PhotoApi
    {
        public static Task<ApiResponse<List<LibraryPhotoSchema>>> GetLibraryPhotos()
        {
            return ApiRequestEngine.ExecuteRequestJson<List<LibraryPhotoSchema>>("getLibrary", null, null, RequestType.Get);
        }
    }
}
