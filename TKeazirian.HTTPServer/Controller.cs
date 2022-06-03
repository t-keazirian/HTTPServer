using System.Text;

namespace TKeazirian.HTTPServer
{
    public static class Controller
    {
        private const string NewLine = "\r\n";

        public static byte[] GenerateOkResponse(string request)
        {
            var body = Parser.BodyParser(request);

            var constructedResponse =
                $"HTTP/1.1 200 OK{NewLine}" +
                $"Content-Type: plain/text{NewLine}" +
                $"Content-Length:{body.Length}{NewLine}{NewLine}" +
                $"{body}";

            var responseToSend = Parser.Encode(constructedResponse);
            return responseToSend;
        }

        public static byte[] GenerateErrorResponse()
        {
            var errorResponse = "HTTP/1.1 500 Internal Server Error";

            var errorResponseToSend = Parser.Encode(errorResponse);
            return errorResponseToSend;
        }
    }
}
