namespace TKeazirian.HTTPServer
{
    public class Controller
    {
        public string EchoRequestBody(string request)
        {
            string responseStatus = Constants.Status200;
            string responseHeaders = Parser.ParseHeaders(request);
            string? responseBody = Parser.ParseRequestBody(request);

            ResponseBuilder responseBuilder = new ResponseBuilder(responseStatus, responseHeaders, responseBody);

            var response = responseBuilder.BuildResponse();

            return response;
        }

        public string CreateResponseForGetRequest(string request)
        {
            string responseStatus = Constants.Status200;
            string responseHeaders = Parser.ParseHeaders(request);
            string responseBody = "Hello world";

            ResponseBuilder responseBuilder = new ResponseBuilder(responseStatus, responseHeaders, responseBody);

            var response = responseBuilder.BuildResponse();

            return response;
        }

        public string ResponseNotFound(string request)
        {
            string responseStatus = Constants.Status404;
            string responseHeaders = Parser.ParseHeaders(request);
            string responseBody = "The resource cannot be found";

            ResponseBuilder responseBuilder = new ResponseBuilder(responseStatus, responseHeaders, responseBody);

            var response = responseBuilder.BuildResponse();
            // var response =
            //     $"HTTP/1.1 404 Not Found" +
            //     $"{Constants.NewLine}{Constants.NewLine}" +
            //     "The resource cannot be found";

            return response;
        }
    }
}
