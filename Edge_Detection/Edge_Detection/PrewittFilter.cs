
namespace Edge_Detection
{
  public class PrewittFilter : EdgeDetectionFilter
  {
    /// <summary>
    /// horizontal matrix for prewitt
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
    protected override double[,] getHorizontalMatrix() => PrewittHorizontal;
    protected override double[,] getVerticalMatrix() => PrewittVertical;
  }
}
