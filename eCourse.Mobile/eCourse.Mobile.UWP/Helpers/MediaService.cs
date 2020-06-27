using eCourse.Mobile.Helpers;
using eCourse.Mobile.UWP.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Xamarin.Forms;

[assembly: Dependency(typeof(MediaService))]
namespace eCourse.Mobile.UWP.Helpers
{
    public class MediaService : IMediaService
    {
        public async Task<byte[]> ResizeImage(byte[] imageData, float width, float height)
        {
            var memStream = new MemoryStream(imageData);

            IRandomAccessStream imageStream = memStream.AsRandomAccessStream();
            var decoder = await BitmapDecoder.CreateAsync(imageStream);
            if (decoder.PixelHeight > height || decoder.PixelWidth > width)
            {
                using (imageStream)
                {
                    var resizedStream = new InMemoryRandomAccessStream();

                    BitmapEncoder encoder = await BitmapEncoder.CreateForTranscodingAsync(resizedStream, decoder);
                    double widthRatio = (double)width / decoder.PixelWidth;
                    double heightRatio = (double)height / decoder.PixelHeight;

                    double scaleRatio = Math.Min(widthRatio, heightRatio);

                    if (width == 0)
                        scaleRatio = heightRatio;

                    if (height == 0)
                        scaleRatio = widthRatio;

                    uint aspectHeight = (uint)Math.Floor(decoder.PixelHeight * scaleRatio);
                    uint aspectWidth = (uint)Math.Floor(decoder.PixelWidth * scaleRatio);

                    encoder.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Linear;

                    encoder.BitmapTransform.ScaledHeight = aspectHeight;
                    encoder.BitmapTransform.ScaledWidth = aspectWidth;

                    await encoder.FlushAsync();
                    resizedStream.Seek(0);
                    var outBuffer = new byte[resizedStream.Size];
                    await resizedStream.ReadAsync(outBuffer.AsBuffer(), (uint)resizedStream.Size, InputStreamOptions.None);
                    return outBuffer;
                }
            }
            return imageData;
        }
    }
}
