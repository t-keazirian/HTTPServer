// using TKeazirian.HTTPServer.Response;
// using Xunit;
//
// namespace TKeazirian.HTTPServer.Tests.Handler;
//
// using TKeazirian.HTTPServer.Handler;
//
// public class HandlerTests
// {
//     [Fact]
//     public void HandleStatusLineGetHandlerFormatsStatusLineWithCorrectVersionStatusText()
//     {
//         string version = Constants.HttpVersion;
//         HttpStatusCode statusCode = HttpStatusCode.Ok;
//
//         ResponseBuilder responseBuilder = new ResponseBuilder();
//         Handler handler = new SimpleGetHandler();
//
//         handler.HandleResponse(request);
//
//         string expectedStatusLine = "HTTP/1.1 200 OK";
//
//         Assert.Equal(expectedStatusLine, responseBuilder.HandleStatusLine());
//     }
//
//     [Fact]
//     public void HandleStatusLineEchoBodyHandlerFormatsStatusLineWithCorrectVersionStatusText()
//     {
//         string version = Constants.HttpVersion;
//         HttpStatusCode statusCode = HttpStatusCode.Ok;
//
//         EchoBodyHandler handler = new EchoBodyHandler();
//
//         string expectedStatusLine = "HTTP/1.1 200 OK";
//
//         Assert.Equal(expectedStatusLine, handler.HandleStatusLine(version, statusCode));
//     }
//
//     [Fact]
//     public void HandleStatusLineRedirectHandlerFormatsStatusLineWithCorrectVersionStatusText()
//     {
//         string version = Constants.HttpVersion;
//         HttpStatusCode statusCode = HttpStatusCode.Moved;
//
//         RedirectHandler handler = new RedirectHandler();
//         string expectedStatusLine = "HTTP/1.1 301 Moved Permanently";
//
//         Assert.Equal(expectedStatusLine, handler.HandleStatusLine(version, statusCode));
//     }
//
//     [Fact]
//     public void HandleStatusLineResourceNotFoundHandlerFormatsStatusLineWithCorrectVersionStatusText()
//     {
//         string version = Constants.HttpVersion;
//         HttpStatusCode statusCode = HttpStatusCode.NotFound;
//
//         ResourceNotFoundHandler handler = new ResourceNotFoundHandler();
//         string expectedStatusLine = "HTTP/1.1 404 Not Found";
//
//         Assert.Equal(expectedStatusLine, handler.HandleStatusLine(version, statusCode));
//     }
// }


