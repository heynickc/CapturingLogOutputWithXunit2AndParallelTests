namespace Lib
{
    using Lib.Logging;

    public class Foo
    {
        private static readonly ILog s_logger = LogProvider.For<Foo>();

        public void Bar(string message)
        {
            s_logger.Info(message);
        }
    }
}