namespace TKeazirian.HTTPServer.Response;

using Handler;
using Request;
using Helpers;

public class HeadResponse
{
    public Response BuildHeadResponse(Handler handler, Request request)
    {
        var getRequest = new Request(
            HttpMethod.GET,
            request.GetRequestPath(),
            request.GetRequestHeaders(),
            request.GetRequestBody()
        );
        var getResponse = handler.HandleResponse(getRequest);

        var headResponse = new Response(
            getResponse.GetStatusLine(),
            getResponse.GetHeaders(),
            ByteConverter.ToByteArray("")
        );
        return headResponse;
    }
}
