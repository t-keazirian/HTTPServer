namespace TKeazirian.HTTPServer
{
    public interface IHandler
    {
        public Response HandleResponse(Request requestObject);

        public List<string> AllowedHttpMethods();


        // public static string SimpleGetNoBody()
        // {
        //     ResponseBuilder responseBuilder = new ResponseBuilder();
        //
        //     var responseStatusLine = Constants.Status200 + Constants.NewLine;
        //     var responseHeaders = "" +
        //                           Constants.NewLine + Constants.NewLine;
        //
        //     return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders, responseBody: null);
        // }
        //
        // public static string CreateResponseForGetRequest()
        // {
        //     ResponseBuilder responseBuilder = new ResponseBuilder();
        //
        //     var responseStatusLine = Constants.Status200 + Constants.NewLine;
        //     var responseHeaders = "Content-Type: text/plain" +
        //                           Constants.NewLine +
        //                           "Content-Length: 11" +
        //                           Constants.NewLine + Constants.NewLine;
        //     var responseBody = "Hello world";
        //
        //     return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders, responseBody);
        // }
        //
        // public static string ResponseNotFound(string request)
        // {
        //     ResponseBuilder responseBuilder = new ResponseBuilder();
        //
        //     var responseStatusLine = Constants.Status404 + Constants.NewLine;
        //     var responseHeaders = "Content-Type: text/plain" +
        //                           Constants.NewLine + Constants.NewLine;
        //     var responseBody = "The resource cannot be found";
        //
        //     return responseBuilder.BuildNewResponse(responseStatusLine, responseHeaders, responseBody);
        // }
    }
}
