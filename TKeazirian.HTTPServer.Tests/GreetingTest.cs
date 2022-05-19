using Xunit;

namespace TKeazirian.HTTPServer.Tests;

public class GreetingTest
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

        var greetingForMorning = Greeting.GetGreeting(hour);

        Assert.Equal("Good Morning!", greetingForMorning);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void TestMultipleHours(int value)
    {
        var greetingForMorning = Greeting.GetGreeting(value);
        Assert.Equal("Good Morning!", greetingForMorning);
    }


    [Fact]
    public void TestGreetingForAfternoon()
    {
        const int hour = 15;

        var greetingForAfternoon = Greeting.GetGreeting(hour);

        Assert.Equal("Good Afternoon!", greetingForAfternoon);
    }

    [Fact]
    public void TestGreetingForEvening()
    {
        const int hour = 20;

        var greetingForEvening = Greeting.GetGreeting(hour);

        Assert.Equal("Good Evening!", greetingForEvening);
    }

    [Fact]
    public void TestGreetingWithNegativeNumber()
    {
        const int hour = -1;

        var greetingOutBounds = Greeting.GetGreeting(hour);

        Assert.Equal("Good Morning!", greetingOutBounds);
    }

    [Fact]
    public void TestGreetingWithNumberAboveTwentyFour()
    {
        const int hour = 27;

        var greetingOutBounds = Greeting.GetGreeting(hour);

        Assert.Equal("Good Evening!", greetingOutBounds);
    }
}
