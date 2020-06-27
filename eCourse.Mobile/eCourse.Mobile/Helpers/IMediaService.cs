using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Mobile.Helpers
{
    public interface IMediaService
    {
        Task<byte[]> ResizeImage(byte[] imageData, float width, float height);
    }
}
