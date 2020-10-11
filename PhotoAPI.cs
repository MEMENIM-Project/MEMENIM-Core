using Memenim.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Memenim.Core
{
    public static class PhotoAPI
    {
        public static async Task<ApiResponse<List<LibraryPhotoData>>> GetLibraryPhotos()
        {
            return await APIHelper.RequestInternal<List<LibraryPhotoData>>("getLibrary", null, requestType: ERequestType.GET);
        }
    }
}
