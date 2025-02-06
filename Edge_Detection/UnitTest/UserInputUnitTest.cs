using Edge_Detection;

namespace UnitTest
{
  public class UserInputUnitTest
  {
    /// <summary>
    /// Test to see correct user input
    /// </summary>
    [Theory]
    [InlineData("1", "SobelFilter")]      //  sobel
    [InlineData("2", "PrewittFilter")]   //  prewitt 
    public void GetUserInput_Valid_ReturnExpectedValue(string input, string output)
    {
      EdgeDetectionFilter result = Program.GetUserInput(input);
      Assert.Equal(output, result.GetType().Name); 
    }

    /// <summary>
    /// Test to see wrong user input
    /// </summary>
    [Theory]
    [InlineData("5")]
    [InlineData("-5")]
    [InlineData("")]
    [InlineData("qwe")]
    public void GetUserInput_Invalid_ThrowException(string input)
    {
      Assert.Throws<ArgumentException>(() => Program.GetUserInput(input));
    }
  }
}
