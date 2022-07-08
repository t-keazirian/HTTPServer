using TKeazirian.HTTPServer.Handler;
using TKeazirian.HTTPServer.Router;
using Xunit;

namespace TKeazirian.HTTPServer.Tests.Router;

using TKeazirian.HTTPServer.Request;
using TKeazirian.HTTPServer.Response;

public class RoutesTest
{
    // [Fact]
    // public void GetCanCallGetHandler()
    // {
    //     Request testRequest = new Request("GET", "/simple_get", "", "");
    //     Routes routes = new Routes(testRequest);
    //
    //     string path = testRequest.GetRequestPath();
    //
    //     Response response = routes.Get(path, new SimpleGetHandler());
    //
    //     Assert.Equal("HTTP/1.1 200 OK\r\n", response.ResponseStatusLine);
    // }
    //
    // [Fact]
    // public void IfGetMethodIsAllowedOnEndpointThenHeadMethodIsAllowed()
    // {
    //     Request testRequest = new Request("HEAD", "/simple_get", "", "");
    //     Routes routes = new Routes(testRequest);
    //
    //     string path = testRequest.GetRequestPath();
    //
    //     Response response = routes.Get(path, new SimpleGetHandler());
    //
    //     Assert.Equal("HTTP/1.1 200 OK\r\n", response.ResponseStatusLine);
    // }
    //
    // [Fact]
    // public void PostCanCallGetHandler()
    // {
    //     Request testRequest = new Request("POST", "/echo_body", "", "");
    //     Routes routes = new Routes(testRequest);
    //
    //     string path = testRequest.GetRequestPath();
    //
    //     Response response = routes.Post(path, new EchoBodyHandler());
    //
    //     Assert.Equal("HTTP/1.1 200 OK\r\n", response.ResponseStatusLine);
    // }
    //
    // [Fact]
    // public void OptionsHandlerHasAllowHeaderWithHeadGetOptionsMethods()
    // {
    //     Routes routes = new Routes();
    //     Request testRequest = new Request("OPTIONS", "/test_path", "", "");
    //     string path = testRequest.GetRequestPath();
    //     string testHeaders = "Allow: GET, HEAD, OPTIONS\r\n\r\n";
    //
    //     Response response = routes.Options(path, new SimpleGetHandler(), testRequest);
    //
    //     Assert.Equal("HTTP/1.1 200 OK\r\n", response.ResponseStatusLine);
    //     Assert.Equal(testHeaders, response.ResponseHeaders);
    //     Assert.Empty(response.GetBody());
    // }
}
