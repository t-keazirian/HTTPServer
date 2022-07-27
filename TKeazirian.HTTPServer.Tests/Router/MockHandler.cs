using TKeazirian.HTTPServer.Helpers;

namespace TKeazirian.HTTPServer.Tests.Router;

using TKeazirian.HTTPServer.Response;
using TKeazirian.HTTPServer.Request;
using Handler;

class MockHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        string responseStatusLine = "HTTP/1.1 200 OK\r\n";
        string responseHeaders = "Content-Type: text/plain\r\nContent-Length: 9\r\n\r\n";
        byte[] responseBody = ByteConverter.ToByteArray("Mock body");
        return new Response(
            responseStatusLine,
            responseHeaders,
            responseBody
        );
    }
}
