namespace TKeazirian.HTTPServer
{
    public class Controller
    {
        private const string NewLine = "\r\n";

        public string EchoRequestBody(string request)
        {
            var body = Parser.ParseBody(request);

            var response =
                $"HTTP/1.1 200 OK{NewLine}" +
                $"Content-Type: plain/text{NewLine}" +
                $"Content-Length:{body.Length}{NewLine}{NewLine}" +
                $"{body}";

            return response;
        }

        public string ResponseNotFound()
        {
            var response =
                $"HTTP/1.1 404 Not Found" +
                $"{NewLine}{NewLine}" +
                "The resource cannot be found";

            return response;
        }
    }
}
