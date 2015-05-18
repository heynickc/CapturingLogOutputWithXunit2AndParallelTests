namespace Lib.Tests
{
    using System;
    using Xunit;
    using Xunit.Abstractions;

    public class Tests : IDisposable
    {
        private readonly IDisposable _logCapture;

        public Tests(ITestOutputHelper outputHelper)
        {
            _logCapture = LoggingHelper.Capture(outputHelper);
        }

        [Fact]
        public void Test1()
        {
            new Foo().Bar("Test1");

            // Check test output for log message.
        }

        [Fact]
        public void Test2()
        {
            new Foo().Bar("Test2");

            // Check test output for log message.
        }

        public void Dispose()
        {
            _logCapture.Dispose();
        }
    }
}