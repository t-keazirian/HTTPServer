namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public interface IHandler
{
    public Response HandleResponse(Request requestObject);

    public List<string> AllowedHttpMethods();
}
