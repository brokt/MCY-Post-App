using System;
using System.IO;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

public partial class mcy_thumbnail_images : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String dosya_adi = Request.QueryString["dosya"];
        Bitmap orjinal = new Bitmap(Server.MapPath(dosya_adi));
        ImageFormat format = orjinal.RawFormat;

        Int32 orjWidth = orjinal.Width;
        Int32 orjHeight = orjinal.Height;

        if (orjHeight < orjWidth)
        {
            if (orjinal.Width <= 349)
            {
                Int32 thumbGenislik = orjinal.Width;

                ImageCodecInfo cInfo;
                if (format.Equals(ImageFormat.Gif) || format.Equals(ImageFormat.Png))
                {
                    cInfo = GetEncoder(ImageFormat.Png);
                    Response.ContentType = "image/png";
                }
                else
                {
                    cInfo = GetEncoder(ImageFormat.Jpeg);
                    Response.ContentType = "image/jpeg";
                }

                Encoder enc = Encoder.Quality;
                EncoderParameters eParams = new EncoderParameters(1);
                EncoderParameter eParam = new EncoderParameter(enc, 85L);
                eParams.Param[0] = eParam;

                Int32 thumbYukseklik = (Int32)((float)thumbGenislik / orjinal.Width * orjinal.Height);
                Bitmap thumbResim = new Bitmap(thumbGenislik, thumbYukseklik);
                Graphics g = Graphics.FromImage(thumbResim);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(orjinal, 0, 0, thumbGenislik, thumbYukseklik);

                Response.Clear();
                thumbResim.Save(Response.OutputStream, cInfo, eParams);
                thumbResim.Dispose();
            }
            else
            {
                Int32 thumbGenislik = 349;

                ImageCodecInfo cInfo;
                if (format.Equals(ImageFormat.Gif) || format.Equals(ImageFormat.Png))
                {
                    cInfo = GetEncoder(ImageFormat.Png);
                    Response.ContentType = "image/png";
                }
                else
                {
                    cInfo = GetEncoder(ImageFormat.Jpeg);
                    Response.ContentType = "image/jpeg";
                }

                Encoder enc = Encoder.Quality;
                EncoderParameters eParams = new EncoderParameters(1);
                EncoderParameter eParam = new EncoderParameter(enc, 85L);
                eParams.Param[0] = eParam;

                Int32 thumbYukseklik = (Int32)((float)thumbGenislik / orjinal.Width * orjinal.Height);
                Bitmap thumbResim = new Bitmap(thumbGenislik, thumbYukseklik);
                Graphics g = Graphics.FromImage(thumbResim);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(orjinal, 0, 0, thumbGenislik, thumbYukseklik);

                Response.Clear();
                thumbResim.Save(Response.OutputStream, cInfo, eParams);
                thumbResim.Dispose();
            }



        }

        if (orjWidth < orjHeight)
        {
            if (orjinal.Height <= 349)
            {
                Int32 thumbYukseklik = orjinal.Height;

                ImageCodecInfo cInfo;
                if (format.Equals(ImageFormat.Gif) || format.Equals(ImageFormat.Png))
                {
                    cInfo = GetEncoder(ImageFormat.Png);
                    Response.ContentType = "image/png";
                }
                else
                {
                    cInfo = GetEncoder(ImageFormat.Jpeg);
                    Response.ContentType = "image/jpeg";
                }

                Encoder enc = Encoder.Quality;
                EncoderParameters eParams = new EncoderParameters(1);
                EncoderParameter eParam = new EncoderParameter(enc, 85L);
                eParams.Param[0] = eParam;

                Int32 thumbGenislik = (Int32)((float)thumbYukseklik / orjinal.Height * orjinal.Width);
                Bitmap thumbResim = new Bitmap(thumbGenislik, thumbYukseklik);
                Graphics g = Graphics.FromImage(thumbResim);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(orjinal, 0, 0, thumbGenislik, thumbYukseklik);

                Response.Clear();
                thumbResim.Save(Response.OutputStream, cInfo, eParams);
                thumbResim.Dispose();
            }
            else
            {
                Int32 thumbYukseklik = 349;

                ImageCodecInfo cInfo;
                if (format.Equals(ImageFormat.Gif) || format.Equals(ImageFormat.Png))
                {
                    cInfo = GetEncoder(ImageFormat.Png);
                    Response.ContentType = "image/png";
                }
                else
                {
                    cInfo = GetEncoder(ImageFormat.Jpeg);
                    Response.ContentType = "image/jpeg";
                }

                Encoder enc = Encoder.Quality;
                EncoderParameters eParams = new EncoderParameters(1);
                EncoderParameter eParam = new EncoderParameter(enc, 85L);
                eParams.Param[0] = eParam;

                Int32 thumbGenislik = (Int32)((float)thumbYukseklik / orjinal.Height * orjinal.Width);
                Bitmap thumbResim = new Bitmap(thumbGenislik, thumbYukseklik);
                Graphics g = Graphics.FromImage(thumbResim);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(orjinal, 0, 0, thumbGenislik, thumbYukseklik);

                Response.Clear();
                thumbResim.Save(Response.OutputStream, cInfo, eParams);
                thumbResim.Dispose();

            }


        }

        if (orjHeight == orjWidth)
        {
            if (orjinal.Height <= 349)
            {
                Int32 thumbGenislik = orjinal.Height;

                ImageCodecInfo cInfo;
                if (format.Equals(ImageFormat.Gif) || format.Equals(ImageFormat.Png))
                {
                    cInfo = GetEncoder(ImageFormat.Png);
                    Response.ContentType = "image/png";
                }
                else
                {
                    cInfo = GetEncoder(ImageFormat.Jpeg);
                    Response.ContentType = "image/jpeg";
                }

                Encoder enc = Encoder.Quality;
                EncoderParameters eParams = new EncoderParameters(1);
                EncoderParameter eParam = new EncoderParameter(enc, 85L);
                eParams.Param[0] = eParam;

                Int32 thumbYukseklik = (Int32)((float)thumbGenislik / orjinal.Width * orjinal.Height);
                Bitmap thumbResim = new Bitmap(thumbGenislik, thumbYukseklik);
                Graphics g = Graphics.FromImage(thumbResim);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(orjinal, 0, 0, thumbGenislik, thumbYukseklik);

                Response.Clear();
                thumbResim.Save(Response.OutputStream, cInfo, eParams);
                thumbResim.Dispose();

            }
            else
            {
                Int32 thumbGenislik = 349;

                ImageCodecInfo cInfo;
                if (format.Equals(ImageFormat.Gif) || format.Equals(ImageFormat.Png))
                {
                    cInfo = GetEncoder(ImageFormat.Png);
                    Response.ContentType = "image/png";
                }
                else
                {
                    cInfo = GetEncoder(ImageFormat.Jpeg);
                    Response.ContentType = "image/jpeg";
                }

                Encoder enc = Encoder.Quality;
                EncoderParameters eParams = new EncoderParameters(1);
                EncoderParameter eParam = new EncoderParameter(enc, 85L);
                eParams.Param[0] = eParam;

                Int32 thumbYukseklik = (Int32)((float)thumbGenislik / orjinal.Width * orjinal.Height);
                Bitmap thumbResim = new Bitmap(thumbGenislik, thumbYukseklik);
                Graphics g = Graphics.FromImage(thumbResim);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(orjinal, 0, 0, thumbGenislik, thumbYukseklik);

                Response.Clear();
                thumbResim.Save(Response.OutputStream, cInfo, eParams);
                thumbResim.Dispose();

            }




        }

        orjinal.Dispose();
    }

    private ImageCodecInfo GetEncoder(ImageFormat format)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.FormatID == format.Guid)
            {
                return codec;
            }
        }
        return null;
    }
}