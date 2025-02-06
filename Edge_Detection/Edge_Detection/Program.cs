using System;
using System.Drawing;
using System.Drawing.Imaging;


namespace Edge_Detection
{
    public class Program
    {
        static void Main(string[] args)
        {
          //get input from user on which filter they want
          EdgeDetectionFilter filter;
          while(true)
          {
            Console.WriteLine("Enter 1 for sobel or 2 for prewitt: ");
            var input = Console.ReadLine();

            try
            {
              filter = GetUserInput(input);
              break;
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
            }
          }

          string basePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

          string inputFolder = Path.Combine(basePath, "input");
          string outputFolder = Path.Combine(basePath, "output");

          ApplyFilterToAll(filter, inputFolder, outputFolder);
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
        public static void ApplyFilterToAll(EdgeDetectionFilter filter, string inputFolder, string outputFolder)
        {
          //ensure an output folder exist 
          Directory.CreateDirectory(outputFolder);

          //get all images in input folder
          string[] jpgImages = Directory.GetFiles(inputFolder, "*.jpg");
          string[] pngImages = Directory.GetFiles(inputFolder, "*.png");
          string[] allImages = jpgImages.Concat(pngImages).ToArray();

          //check if input folder has any images that is  in the correct format
          if(allImages.Length == 0)
            throw new FileNotFoundException("Input folder is empty or doesnt contain images with the .png or .jpg format.\n");
          
          Console.Write("applying filter\n");
          //apply filter to all images
          foreach (string image in allImages)
          {
            try
            { 
                Bitmap photo = new(image);
                Bitmap grayImage = ConvertToGrayScale(photo);
                Bitmap filterImage = filter.ApplyFilter(grayImage);
    
                string outPutImage = Path.Combine(outputFolder, Path.GetFileName(image));
                filterImage.Save(outPutImage);    
            }
            catch(Exception ex)
            {
              Console.WriteLine($"Error with {image}: {ex.Message}\n");
            }
          }

          Console.Write("filter applied\n");
        }

        public static EdgeDetectionFilter GetUserInput(string input)
        {
          //ensures user input correctly if not ask user again
          if (int.TryParse(input, out int userInput) && (userInput == 1 || userInput == 2))
          {
            return userInput switch
            {
              1 => new SobelFilter(),
              2 => new PrewittFilter(),
              _ => throw new ArgumentException("Invalid input! Please enter 1 for sobel or 2 for prewitt ")
            };
          }

          throw new ArgumentException("Invalid input! Please enter 1 for sobel or 2 for prewitt ");
        }
    }
}
