using System.Drawing;


namespace Edge_Detection
{
  /// <summary>
  /// A edge detection using sobel 
  /// </summary>
  public static class Sobel
  {
    public static Bitmap ApplySobel(Bitmap image)
    {
      int width = image.Width;
      int height = image.Height;
      Bitmap sobelImage = new(width, height);

      for (int y = 1; y < height - 1; y++)
      {
        for (int x = 1; x < width - 1; x++)
        {
          double gradX = 0, gradY = 0;

          //apply the sobel matrix 
          for (int i = -1; i < 2; i++)
          {
            for (int j = -1; j < 2; j++)
            {
              int pixVal = image.GetPixel(x + j, y + i).R;
              gradX += pixVal * Matrix.SobelHorizontal[i + 1 , j + 1];
              gradY += pixVal * Matrix.SobelVertical[i + 1, j + 1];
            }
          }

          // get the magnitude of the gradient 
          int mag = Math.Min(255, (int)Math.Sqrt(gradX * gradX + gradY * gradY));
          sobelImage.SetPixel(x, y, Color.FromArgb(mag, mag, mag));
        }
      }

      return sobelImage;
    }
  }
}
