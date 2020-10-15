using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Memenim.Core.Data;

namespace Memenim.Core.Api
{
    public static class PhotoApi
    {
        public static Task<ApiResponse<List<LibraryPhotoData>>> GetLibraryPhotos()
        {
            return ApiRequestEngine.ExecuteRequestJson<List<LibraryPhotoData>>("getLibrary", null, null, RequestType.Get);
        }
    }
}
