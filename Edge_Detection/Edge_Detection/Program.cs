using System;
using System.Drawing;
using System.Drawing.Imaging;


namespace Edge_Detection
{
    class Program
    {
        static void Main(string[] args)
        {
          //get input from user on which filter they want
          int userInput = 0;
          while(true)
          {
            Console.WriteLine("Enter 1 for sobel or 2 for prewitt: ");
            var input = Console.ReadLine();

            //ensures user input correctly if not ask user again
            if (int.TryParse(input, out userInput) && (userInput == 1 || userInput == 2))
              break;

            Console.WriteLine("Invalid input! Please enter 1 for sobel or 2 for prewitt ");
          }

          ApplyFilterToAll(userInput);
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

        /// <summary>
        /// A function grab all images in the input folder and apply the edge filter to all and save it to the output folder
        /// </summary>
        static void ApplyFilterToAll(int userInput)
        {
          string basePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

          string inputFolder = Path.Combine(basePath, "input");
          string outputFolder = Path.Combine(basePath, "output");

          //ensure an output folder exist 
          Directory.CreateDirectory(outputFolder);
          Console.Write("applying filter\n");

          //get all images in input folder
          string[] jpgImages = Directory.GetFiles(inputFolder, "*.jpg");
          string[] pngImages = Directory.GetFiles(inputFolder, "*.png");
          string[] allImages = jpgImages.Concat(pngImages).ToArray();

          //apply filter to all images
          foreach (string image in allImages)
          {
            Bitmap photo = new(image);
            Bitmap grayImage = ConvertToGrayScale(photo);
            Bitmap filterImage = EdgeDetectionFilter.ApplyFilter(grayImage, userInput);

            string outPutImage = Path.Combine(outputFolder, Path.GetFileName(image));
            filterImage.Save(outPutImage);
          }

          Console.Write("filter applied\n");
        }
    }
}
