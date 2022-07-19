namespace TKeazirian.HTTPServer.Handler;

using Request;
using Response;

public class XmlHandler : Handler
{
    public override Response HandleResponse(Request request)
    {
        string body = "<note><body>XML Response</body></note>";
        return new ResponseBuilder()
            .SetStatusCode(HttpStatusCode.Ok)
            .SetHeaders(ResponseHeaderName.ContentType, ContentType.Xml)
            .SetHeaders(ResponseHeaderName.ContentLength, body.Length.ToString())
            .SetBody(body)
            .Build();
    }
}
