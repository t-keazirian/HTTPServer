namespace EchoServer
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var g = new Greeting();
            var hour = DateTime.Now.Hour;
            string greeting = g.GetGreeting(hour);
            Console.WriteLine(greeting);
        }
    }
}
