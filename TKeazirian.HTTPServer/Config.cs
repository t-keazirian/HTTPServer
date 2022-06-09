using System.ComponentModel.Design;
using TKeazirian.HTTPServer;

namespace TKeazirian.HTTPServer;

class Config
{
    public Dictionary<string, string> routes = new Dictionary<string, string>();

    public Dictionary<string, string> RoutesDictionary(string request)
    {
        Controller controller = new Controller();
        routes.Add("/echo_body", controller.EchoRequestBody(request));
        return routes;
    }
}
