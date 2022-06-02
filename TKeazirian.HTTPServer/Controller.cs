using System.Text;

namespace TKeazirian.HTTPServer
{
    public static class Controller
    {
        public static byte[] GenerateResponse(string request)
        {
            var splitString = request.Split('\r');

            var body = splitString[^1];

            var constructedResponse = $"HTTP/1.1 200 OK\r\r{body}";

            var responseToSend = Encoding.ASCII.GetBytes(constructedResponse);
            return responseToSend;
        }

        public static byte[] GenerateErrorResponse()
        {
            var errorResponse = "HTTP/1.1 500 Internal Server Error";

            var errorResponseToSend = Encoding.ASCII.GetBytes(errorResponse);
            return errorResponseToSend;
        }
    }
}
