using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace Wx.Utility.Collections
{
    /// <summary>
    /// 图片帮助类
    /// </summary>
    public static class PicHelper
    {
        public static byte[] ImageToBytes(Image image)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                else if (format.Equals(ImageFormat.Png))
                {
                    image.Save(ms, ImageFormat.Png);
                }
                else if (format.Equals(ImageFormat.Bmp))
                {
                    image.Save(ms, ImageFormat.Bmp);
                }
                else if (format.Equals(ImageFormat.Gif))
                {
                    image.Save(ms, ImageFormat.Gif);
                }
                else if (format.Equals(ImageFormat.Icon))
                {
                    image.Save(ms, ImageFormat.Icon);
                }
                byte[] buffer = new byte[ms.Length];
                //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        /// <summary>
        /// 生成tmp临时图片
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string CreateImageFromBytes(string path, string fileName, byte[] buffer)
        {
            Bitmap bmp = new Bitmap(BytesToStream(buffer));
            
            ImageFormat format = bmp.RawFormat;
            if (format.Equals(ImageFormat.Jpeg))
            {
                fileName += ".jpeg";
            }
            else if (format.Equals(ImageFormat.Png))
            {
                fileName += ".jpeg";
            }
            else if (format.Equals(ImageFormat.Bmp))
            {
                fileName += ".jpeg";
            }
            else if (format.Equals(ImageFormat.Gif))
            {
                fileName += ".jpeg";
            }
            else if (format.Equals(ImageFormat.Icon))
            {
                fileName += ".jpeg";
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            string file = path + fileName;
            File.WriteAllBytes(file, buffer);
            return fileName;
        }

        /// <summary>
        /// 输出图片
        /// </summary>
        /// <param name="pic"></param>
        /// <param name="res"></param>
        public static void RespondPicture(byte[] pic, HttpResponse res)
        {
            if (pic != null)
            {
                res.ContentType = "application/octet-stream";
                res.AddHeader("Content-Disposition", "attachment;FileName= picture.JPG");
                res.BinaryWrite(pic);
            }
        }

        /// <summary>
        /// 图片旋转
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap KiRotate90(Bitmap img)
        {
            try
            {
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                return img;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Stream 转 二进制
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        /// <summary>
        /// 将 byte[] 转成 Stream
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
