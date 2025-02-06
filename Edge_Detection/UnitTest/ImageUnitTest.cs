using Edge_Detection;

namespace UnitTest
{
  public class ImageUnitTest
  {
    /// <summary>
    /// Test to see an exception thrown when input folder is empty
    /// </summary>
    [Theory]
    [InlineData("1")] //  sobel
    [InlineData("2")] //  prewitt 
    public void ApplyFilterToAll_EmptyFolder_ThrowsException(string userInput)
    {
      string basePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

      Directory.CreateDirectory(Path.Combine(basePath, "testemptyimage"));
      string inputFolder = Path.Combine(basePath, "testemptyimage");
      string outputFolder = Path.Combine(basePath, "output");
      EdgeDetectionFilter filter = Program.GetUserInput(userInput);

      Assert.Throws<FileNotFoundException>(() => Program.ApplyFilterToAll(filter, inputFolder, outputFolder));
    }

    /// <summary>
    /// Test to see when the filter is applied
    /// </summary>
    [Theory]
    [InlineData("1")] //  sobel
    [InlineData("2")] //  prewitt 
    public void ApplyFilterToAll_Valid_FilterApplied(string userInput)
    {
      string basePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

      string inputFolder = Path.Combine(basePath, "testimages");
      string outputFolder = Path.Combine(basePath, "output");

      //clear output folder to ensure no overlap
      System.IO.DirectoryInfo di = new DirectoryInfo(outputFolder);
      foreach (FileInfo file in di.EnumerateFiles())
      {
        file.Delete();
      }

      EdgeDetectionFilter filter = Program.GetUserInput(userInput);
      Program.ApplyFilterToAll(filter, inputFolder, outputFolder);

      string[] inputJPGImages = Directory.GetFiles(inputFolder, "*.jpg");
      string[] inputPNGImages = Directory.GetFiles(inputFolder, "*.png");

      string[] outputJPGImages = Directory.GetFiles(outputFolder, "*.jpg");
      string[] outputPNGImages = Directory.GetFiles(outputFolder, "*.png");

      //the images saved would be the same as input, 1 for jpg and 1 for png
      Assert.Equal(inputJPGImages.Length, outputJPGImages.Length);
      Assert.Equal(inputPNGImages.Length, outputPNGImages.Length);
    }
  }
}
