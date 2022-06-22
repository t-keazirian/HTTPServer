namespace TKeazirian.HTTPServer.Handler;

using Response;
using Request;

public abstract class Handler
{
    public virtual List<string> AllowedHttpMethods()
    {
        throw new Exception("Method not implemented");
    }

    public virtual Response HandleResponse(Request requestObject)
    {
        throw new Exception("Method not implemented");
    }

    public string HandleStatusLine(string httpVersion, HttpStatusCode responseStatusCode)
    {
        return httpVersion + Constants.Space + (int)responseStatusCode + Constants.Space +
               StatusMessages.GetMessage(responseStatusCode);
    }
}
