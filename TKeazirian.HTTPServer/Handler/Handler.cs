namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public abstract class Handler
{
    public virtual Response HandleResponse(Request request)
    {
        throw new Exception("Method not implemented");
    }
}
