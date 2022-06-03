using System.Text;

namespace TKeazirian.HTTPServer
{
    public static class Controller
    {
        private const string NewLine = "\r\n";

        public static string EchoRequestBody(string request)
        {
            var body = Parser.ParseBody(request);

            var response =
                $"HTTP/1.1 200 OK{NewLine}" +
                $"Content-Type: plain/text{NewLine}" +
                $"Content-Length:{body.Length}{NewLine}{NewLine}" +
                $"{body}";

            return response;
        }
    }
}
