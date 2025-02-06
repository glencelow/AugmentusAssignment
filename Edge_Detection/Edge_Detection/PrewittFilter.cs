
namespace Edge_Detection
{
  public class PrewittFilter : EdgeDetectionFilter
  {
    protected override double[,] getHorizontalMatrix() => Matrix.PrewittHorizontal;
    protected override double[,] getVerticalMatrix() => Matrix.PrewittVertical;
  }
}
