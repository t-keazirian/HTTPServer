using System.ComponentModel.Design;
using TKeazirian.HTTPServer;

namespace TKeazirian.HTTPServer;

class Config
{
    Dictionary<string, string> routes = new Dictionary<string, string>();

    public static void RoutesDictionary(string request)
    {
        // routes.Add("/echo_body", Controller.EchoRequestBody(request));
        // return RoutesDictionary;
    }


    //     {
//         "post":
//         {
//             "/echo_body": Controller.EchoRequestBody;
//         }
//     },
//     {
//         "get":
//         {
//             "/simple_get": Controller.SimpleGet;
//         }
// }
}
