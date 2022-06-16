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

            ResponseBuilder responseBuilder = new ResponseBuilder();

            var response = responseBuilder.BuildResponseForGet(responseStatus);

            return response;
        }

        public string ResponseNotFound(string request)
        {
            string responseStatus = Constants.Status404;

            ResponseBuilder responseBuilder = new ResponseBuilder();

            var response = responseBuilder.BuildResponseForResourceNotFound(responseStatus);

            return response;
        }
    }
}
