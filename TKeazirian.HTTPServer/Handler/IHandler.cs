namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public interface IHandler
{
    public List<string> AllowedHttpMethods();
    public Response HandleResponse(Request requestObject);
}
