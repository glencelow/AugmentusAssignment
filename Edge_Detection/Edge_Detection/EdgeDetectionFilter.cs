using System.Drawing;


namespace Edge_Detection
{
  /// <summary>
  /// An edge detection filter using either sobel or prewitt
  /// </summary>
  public static class EdgeDetectionFilter
  {
    public static Bitmap ApplyFilter(Bitmap image, int userInput)
    {
      int width = image.Width;
      int height = image.Height;
      Bitmap sobelImage = new(width, height);

      for (int y = 1; y < height - 1; y++)
      {
        for (int x = 1; x < width - 1; x++)
        {
          double gradX = 0, gradY = 0;

          //apply the filter matrix depending on the user
          for (int i = -1; i < 2; i++)
          {
            for (int j = -1; j < 2; j++)
            {
              int pixVal = image.GetPixel(x + j, y + i).R;
              if (userInput == 1)
              { 
                gradX += pixVal * Matrix.SobelHorizontal[i + 1 , j + 1];
                gradY += pixVal * Matrix.SobelVertical[i + 1, j + 1];
              }
              else
              {
                gradX += pixVal * Matrix.PrewittHorizontal[i + 1, j + 1];
                gradY += pixVal * Matrix.PrewittVertical[i + 1, j + 1];
              }
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
