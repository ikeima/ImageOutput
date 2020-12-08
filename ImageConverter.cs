using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageOutput
{
    class ImageConverter
    {
        public static byte[] ConvertToByte(string fileName)
        {
            if (fileName != "")
            {
                Image image = Image.FromFile(fileName);

                byte[] imageToDB;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, ImageFormat.Png);
                    imageToDB = memoryStream.ToArray();
                }
                return imageToDB;
            }
            else return null;
        }
    }
}
