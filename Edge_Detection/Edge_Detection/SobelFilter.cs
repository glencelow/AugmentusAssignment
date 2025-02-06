namespace Edge_Detection
{
  public class SobelFilter : EdgeDetectionFilter
  {
    protected override double[,] getHorizontalMatrix() => Matrix.SobelHorizontal;
    protected override double[,] getVerticalMatrix() => Matrix.SobelVertical;
  }
}
