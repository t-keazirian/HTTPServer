namespace TKeazirian.HTTPServer.Handler
{
    public interface IHandler
    {
        public Response.Response HandleResponse(Request.Request requestObject);

        public List<string> AllowedHttpMethods();
    }
}
