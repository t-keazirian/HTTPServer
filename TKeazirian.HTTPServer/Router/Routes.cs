// namespace TKeazirian.HTTPServer.Router;
//
// using Response;
// using Request;
//
// public class Routes
// {
//     // private readonly Dictionary<string, Route> _routes;
//     private readonly List<Route> _routes;
//
//     public Routes()
//     {
//         // _routes = new Dictionary<string, Route>();
//         _routes = new List<Route>();
//     }
//
//     public void AddRoute(Route route)
//     {
//         _routes.Add(route);
//         // _routes.Add(route.Path, route);
//     }
//
//     public Route GetRoute(string path)
//     {
//         return _routes[path];
//     }
//
//     public bool PathExists(string path)
//     {
//         return _routes.ContainsKey(path);
//     }
//
//     public Response HandleRespond(Request request, Route route)
//     {
//         return route.Handler.HandleResponse(request);
//     }
// }
