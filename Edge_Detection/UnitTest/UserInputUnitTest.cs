using Edge_Detection;

namespace UnitTest
{
  public class UserInputUnitTest
  {
    /// <summary>
    /// Test to see correct user input
    /// </summary>
    [Theory]
    [InlineData("1", 1)] //  sobel
    [InlineData("2", 2)] //  prewitt 
    public void GetUserInput_Valid_ReturnExpectedValue(string input, int output)
    {
      int result = Program.GetUserInput(input);
      Assert.Equal(output, result); 
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
