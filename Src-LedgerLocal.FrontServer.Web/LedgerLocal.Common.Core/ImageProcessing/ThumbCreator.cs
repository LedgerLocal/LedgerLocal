using System;

namespace LedgerLocal.Common.Core
{
    public class ThumbCreator
    {
        //public static void CreateThumb(System.Drawing.Bitmap originalImage, string thumbPath, int width, int height, System.Drawing.Brush drawBackColor, System.Drawing.ImageFormat imageFormat)
        //{
        //    var widthOrig = originalImage.Width;
        //    var heightOrig = originalImage.Height;

        //    var fx = (double)widthOrig / width;
        //    var fy = (double)heightOrig / height;

        //    var f = System.Math.Max(fx, fy);

        //    if (f < 1) f = 1;

        //    var heightTh = (heightOrig / f);
        //    var widthTh = (widthOrig / f);

        //    var intWidthTh = Convert.ToInt32(widthTh);
        //    var intHeightTh = Convert.ToInt32(heightTh);

        //    intWidthTh = intWidthTh > width ? width : intWidthTh;
        //    intHeightTh = intHeightTh > height ? height : intHeightTh;

        //    using (var thumb = new Bitmap(width, height))
        //    {
        //        using (var g = Graphics.FromImage(thumb))
        //        {
        //            g.SmoothingMode = SmoothingMode.HighQuality;
        //            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

        //            g.FillRectangle(drawBackColor, new Rectangle(0, 0, width, height));
        //            g.DrawImage(originalImage, new Rectangle((width / 2) - (intWidthTh / 2), (height / 2) - (intHeightTh / 2), intWidthTh, intHeightTh));

        //            thumb.Save(thumbPath, imageFormat);
        //        }
        //    }
        //}

        //public static void CreateThumbNoBackImage(Bitmap originalImage, string thumbPath, int width, int height, ImageFormat imageFormat)
        //{
        //    var widthOrig = originalImage.Width;
        //    var heightOrig = originalImage.Height;

        //    var fx = (double)widthOrig / width;
        //    var fy = (double)heightOrig / height;

        //    var f = System.Math.Max(fx, fy);

        //    if (f < 1) f = 1;

        //    var heightTh = (heightOrig / f);
        //    var widthTh = (widthOrig / f);

        //    var intWidthTh = Convert.ToInt32(widthTh);
        //    var intHeightTh = Convert.ToInt32(heightTh);

        //    intWidthTh = intWidthTh > width ? width : intWidthTh;
        //    intHeightTh = intHeightTh > height ? height : intHeightTh;

        //    using (var thumb = new Bitmap(intWidthTh, intHeightTh))
        //    {
        //        using (var g = Graphics.FromImage(thumb))
        //        {
        //            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

        //            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, intWidthTh, intHeightTh));

        //            thumb.Save(thumbPath, imageFormat);
        //        }
        //    }
        //}

        //public static void MakeThumbnail(string originalPath, string thumbPath, int thumbSize)
        //{
        //    var bmp = new System.Drawing.Bitmap(originalPath);

        //    //these are just arbitary numbers -- if the image is larger than this, create a 100px max by 100px max thumbnail defined by the constant at the start

        //    var percent = DeterminePercentageForResize(bmp.Height, bmp.Width, thumbSize);
        //    var floatWidth = bmp.Width * percent;
        //    var floatHeight = bmp.Height * percent;
        //    var width = Convert.ToInt32(floatWidth);
        //    var height = Convert.ToInt32(floatHeight);

        //    var thumb = bmp.GetThumbnailImage(width, height, ThumbnailCallback, IntPtr.Zero);

        //    //Set Image codec of JPEG type, the index of JPEG codec is "1"
        //    var codec = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1];

        //    //Set the parameters for defining the quality of the thumbnail... here it is set to 100%
        //    var eParams = new System.Drawing.Imaging.EncoderParameters(1);
        //    eParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);

        //    thumb.Save(thumbPath, codec, eParams);
        //}

        private static float DeterminePercentageForResize(int height, int width, int thumbSize)
        {
            var highestValue = height > width ? height : width;

            var percent = (float)thumbSize / highestValue;

            if (percent > 1 && percent != 0)
                throw new Exception("Percent cannot be greater than 1 or equal to zero");

            return percent;
        }

        public static bool ThumbnailCallback()
        {
            return false;
        }
    }
}
