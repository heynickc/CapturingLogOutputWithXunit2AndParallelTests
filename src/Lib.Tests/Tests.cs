namespace Lib.Tests
{
    using System;
    using System.Threading;
    using Xunit;
    using Xunit.Abstractions;

    public class TestClass1 : IDisposable
    {
        private readonly IDisposable _logCapture;

        public TestClass1(ITestOutputHelper outputHelper)
        {
            _logCapture = LoggingHelper.Capture(outputHelper);
        }

        [Fact]
        public void Test1()
        {
            new Foo().Bar("Test1");

            // Check test output for log message.
        }

        public void Dispose()
        {
            _logCapture.Dispose();
        }
    }

    public class TestClass2 : IDisposable
    {
        private readonly IDisposable _logCapture;

        public TestClass2(ITestOutputHelper outputHelper)
        {
            _logCapture = LoggingHelper.Capture(outputHelper);
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