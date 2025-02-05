using System;
using System.Drawing;
using System.Drawing.Imaging;


namespace Edge_Detection
{
    class Program
    {
        static void Main(string[] args)
        {
          string basePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
          string imagePath = Path.Combine(basePath, "Photo", "lena.png");
          Bitmap image = new(imagePath);
          Bitmap grayImage = ConvertToGrayScale(image);

          Console.Write("applying sobel filter\n");
          Bitmap sobelImage = Sobel.ApplySobel(grayImage);
          string newImagePath = Path.Combine(basePath, "Photo", "sobelImage.jpg");
          sobelImage.Save(newImagePath, ImageFormat.Jpeg);
          Console.Write("sobel applied\n");
        }

        /// <summary>
        /// a function to convert an image into grayscale
        /// </summary>
        static Bitmap ConvertToGrayScale(Bitmap image)
        {
          Bitmap grayImage = new(image.Width, image.Height);
          for (int y = 0; y < image.Height; y++)
          {
            for (int x = 0; x < image.Width; x++)
            {
              Color pixel = image.GetPixel(x, y);
              int gray = (int)(pixel.R * 0.3 +  pixel.G * 0.59 + pixel.B * 0.11);
              grayImage.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
            }
          }
          return grayImage;
        }
    }
}
