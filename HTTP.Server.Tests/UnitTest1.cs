using TKeazirian.Web.HTTPServer;
using Xunit;

namespace HTTP.Server.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Assert.True(true);
    }

    [Fact]
    public void TestGreetingForMorning()
    {
        const int hour = 11;
        var greeting = new Greeting();

        var greetingForMorning = greeting.GetGreeting(hour);

        Assert.Equal("Good Morning!", greetingForMorning);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void TestMultipleHours(int value)
    {
        var greeting = new Greeting();

        var greetingForMorning = greeting.GetGreeting(value);
        Assert.Equal("Good Morning!", greetingForMorning);
    }


    [Fact]
    public void TestGreetingForAfternoon()
    {
        const int hour = 15;
        var greeting = new Greeting();

        var greetingForAfternoon = greeting.GetGreeting(hour);

        Assert.Equal("Good Afternoon!", greetingForAfternoon);
    }

    [Fact]
    public void TestGreetingForEvening()
    {
        const int hour = 20;
        var greeting = new Greeting();

        var greetingForEvening = greeting.GetGreeting(hour);

        Assert.Equal("Good Evening!", greetingForEvening);
    }

    [Fact]
    public void TestGreetingWithNegativeNumber()
    {
        const int hour = -1;
        var greeting = new Greeting();

        var greetingOutBounds = greeting.GetGreeting(hour);

        Assert.Equal("Good Morning!", greetingOutBounds);
    }

    [Fact]
    public void TestGreetingWithNumberAboveTwentyFour()
    {
        const int hour = 27;
        var greeting = new Greeting();

        var greetingOutBounds = greeting.GetGreeting(hour);

        Assert.Equal("Good Evening!", greetingOutBounds);
    }
}
