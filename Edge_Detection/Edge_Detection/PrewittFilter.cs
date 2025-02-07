
namespace Edge_Detection
{
  /// <summary>
  /// A class that inherent from EdgeDetectionFilter to set the matrix it will use to prewitt 
  /// </summary>
  public class PrewittFilter : EdgeDetectionFilter
  {
    /// <summary>
    /// A class that inherent from EdgeDetectionFilter to set the matrix it will use to prewitt 
    /// </summary>
    static double[,] PrewittHorizontal
    {
      get
      {
        return new double[,]
        { { -1, 0, 1 },
          { -1, 0, 1 },
          { -1, 0, 1 }, };
      }
    }

    /// <summary>
    /// vertical matrix for prewitt
    /// </summary>
    static double[,] PrewittVertical
    {
      get
      {
        return new double[,]
        { {  1,  1,  1 },
          {  0,  0,  0 },
          { -1, -1, -1 }, };
      }
    }
    protected override double[,] GetHorizontalMatrix() => PrewittHorizontal;
    protected override double[,] GetVerticalMatrix() => PrewittVertical;
  }
}
