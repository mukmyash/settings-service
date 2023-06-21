namespace Settings.Service.Test;

public class ParamsExtracterTest
{
    [Theory]
    [InlineData("", new string[0])]
    [InlineData("test", new string[0])]
    [InlineData("${value1}", new [] {"value1"})]
    [InlineData("test ${value1}", new [] {"value1"})]
    [InlineData("${value1} ${value2}", new [] {"value1", "value2"})]
    [InlineData("Val = ${value1}, Val = ${value2}", new [] {"value1", "value2"})]
    public void ParamsExtracter_GetParams_Success(string inputValue, string[] expectedVariables)
    {
        new ParamsExtracter()
            .GetParams(inputValue)
            .Should()
            .BeEquivalentTo(expectedVariables);
    }
}