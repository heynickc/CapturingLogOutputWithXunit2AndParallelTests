# Capturing test specific log output when using xunit 2.x parallel testing

xunit 2.x now enables parallel testing by default. According to the docs, using console to output messages is no longer viable:

> When xUnit.net v2 shipped with parallelization turned on by default, this output capture mechanism was no longer appropriate; it is impossible to know which of the many tests that could be running in parallel were responsible for writing to those shared resources. 

The recommend approach is now to take a dependency on `ITestOutputHelper` on your test class.

But what if  you are using a library with logging support, perhaps a 3rd party one, and you want to capture it's log output in your test output?

Because logging is considered a cross-cutting concern, the _typical_ usage is to declare a logger as a static shared resource in a class.

	public class Foo
    {
    	private static readonly ILog s_logger = LogProvider.For<Foo>();
    }

The issue here is that if this class is used in a concurrent way, it's log output will be interleaved.

### Solution

The typical approach to message correlation with logging is to use [diagnostic contexts](https://logging.apache.org/log4j/1.2/apidocs/org/apache/log4j/NDC.html). That is, attach a correlation id to each log message.

In this sample solution, we

 1. Using serilog, we capture all log output to an `IObservable<LogEvent>`
 2. When each test class is instantiated, we open a unique diagnostic context, subscribe and _filter_ log messages for that context and pipe them to the test classes' `ITestOutputHelper` instance. This is done [here](https://github.com/damianh/CapturingLogOutputWithXunit2AndParallelTests/blob/master/src/Lib.Tests/LoggingHelper.cs#L31-L45). 
 3. When the test class is disposed, the subscription and the context is disposed.

Notes:
 1. While we used [LibLog](https://github.com/damianh/LibLog) in the sample library, the same approach applies to any library that defines it's own logging abstraction or has a dependency on a logging framework.
 2. While we used [Serilog](http://serilog.net) to wire up the observable sink, we could probably do similar with another logging framework (NLog, Log4Net etc).
