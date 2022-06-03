using System.Text;

namespace TKeazirian.HTTPServer
{
    public static class Controller
    {
        public static byte[] GenerateOkResponse(string request)
        {
            var splitString = Parser.SplitString(request);

            var body = splitString[^1];

            var constructedResponse = $"HTTP/1.1 200 OK\r\r{body}";

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
