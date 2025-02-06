using System.Drawing;


namespace Edge_Detection
{
  /// <summary>
  /// An edge detection filter using either sobel or prewitt
  /// </summary>
  public abstract class EdgeDetectionFilter
  {
    protected abstract double[,] getHorizontalMatrix();
    protected abstract double[,] getVerticalMatrix();

    public Bitmap ApplyFilter(Bitmap image)
    {
      int width = image.Width;
      int height = image.Height;
      Bitmap filterImage = new(width, height);

      double[,] horizontalMatrix = getHorizontalMatrix();
      double[,] verticalMatrix = getVerticalMatrix();

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
              gradX += pixVal * horizontalMatrix[i + 1 , j + 1];
              gradY += pixVal * verticalMatrix[i + 1, j + 1];
            }
          }

          // get the magnitude of the gradient 
          int mag = Math.Min(255, (int)Math.Sqrt(gradX * gradX + gradY * gradY));
          filterImage.SetPixel(x, y, Color.FromArgb(mag, mag, mag));
        }
      }

      return filterImage;
    }
  }
}
