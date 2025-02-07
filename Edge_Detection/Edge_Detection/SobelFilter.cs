namespace Edge_Detection
{
  /// <summary>
  /// A class that inherent from EdgeDetectionFilter to set the matrix it will use to sobel 
  /// </summary>
  public class SobelFilter : EdgeDetectionFilter
  {
    /// <summary>
    /// horizontal matrix for sobel
    /// </summary>
    static double[,] SobelHorizontal
    {
      get
      {
        return new double[,]
        { { -1, 0, 1 },
          { -2, 0, 2 },
          { -1, 0, 1 }, };
      }
    }

    /// <summary>
    /// vertical matrix for sobel
    /// </summary>
    static double[,] SobelVertical
    {
      get
      {
        return new double[,]
        { {  1,  2,  1 },
          {  0,  0,  0 },
          { -1, -2, -1 }, };
      }
    }

    protected override double[,] GetHorizontalMatrix() => SobelHorizontal;
    protected override double[,] GetVerticalMatrix() => SobelVertical;
  }
}
