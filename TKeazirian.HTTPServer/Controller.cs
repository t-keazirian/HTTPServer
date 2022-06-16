namespace TKeazirian.HTTPServer
{
    public class Controller
    {
        public string EchoRequestBody(string request)
        {
            string responseStatus = Constants.Status200;
            string responseHeaders = Parser.ParseHeaders(request);
            string responseBody = Parser.ParseRequestBody(request);

            ResponseBuilder responseBuilder = new ResponseBuilder();

            var response = responseBuilder.BuildResponse(responseStatus, responseHeaders, responseBody);

            return response;
        }

        public string SimpleGetNoBody(string request)
        {
            string responseStatus = Constants.Status200;
            string responseHeaders = Parser.ParseHeaders(request);
            string responseBody = Parser.ParseRequestBody(request);

            ResponseBuilder responseBuilder = new ResponseBuilder();

            var response = responseBuilder.BuildResponse(responseStatus, responseHeaders, responseBody);

            return response;
        }

        public string CreateResponseForGetRequest(string request)
        {
            string responseStatus = Constants.Status200;
            string responseHeaders = Parser.ParseHeaders(request);

            ResponseBuilder responseBuilder = new ResponseBuilder();

            var response = responseBuilder.BuildResponseForGet(responseStatus, responseHeaders);

            return response;
        }

        public string ResponseNotFound(string request)
        {
            string responseStatus = Constants.Status404;
            string responseHeaders = Parser.ParseHeaders(request);

            ResponseBuilder responseBuilder = new ResponseBuilder();

            var response = responseBuilder.BuildResponseForResourceNotFound(responseStatus, responseHeaders);

            return response;
        }
    }
}
