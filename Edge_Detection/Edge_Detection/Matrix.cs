namespace Edge_Detection
{

  /// <summary>
  /// A matrix class which contains horizontal and vertical kernels for sobel and prewitt to apply 
  /// </summary>
  public static class Matrix
  {

    /// <summary>
    /// horizontal matrix for sobel
    /// </summary>
    public static double[,] sobelHorizontal
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
    public static double[,] sobelVertical
    {
      get
      {
        return new double[,]
        { {  1,  2,  1 },
          {  0,  0,  0 },
          { -1, -2, -1 }, };
      }
    }

    /// <summary>
    /// horizontal matrix for prewitt
    /// </summary>
    public static double[,] prewittHorizontal
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
    public static double[,] prewittVertical
    {
      get
      {
        return new double[,]
        { {  1,  1,  1 },
          {  0,  0,  0 },
          { -1, -1, -1 }, };
      }
    }


  }
}
