namespace Lib.Tests
{
    using Xunit;
    using Xunit.Abstractions;

    public class FooTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public FooTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void When_bar_then_should()
        {
            using(LoggingHelper.Capture(_outputHelper))
            {
                var sut = new Foo();

                sut.Bar();

                // Check test output for log message.
            }
        }
    }
}