namespace TKeazirian.HTTPServer;

public class Router
{
    public IHandler GetHandler(Request requestObject)
    {
        if (ResourceHandlerDictionary().ContainsKey(requestObject.GetRequestPath()) &&
            IsHttpMethodAllowed(requestObject))
        {
            return ResourceHandlerDictionary()[requestObject.GetRequestPath()];
        }

        return null;
    }

    private Dictionary<string, IHandler> ResourceHandlerDictionary()
    {
        Dictionary<string, IHandler> resourceHandlerDictionary =
            new Dictionary<string, IHandler>
            {
                { "/echo_body", new EchoRequestBody() },
                { "/simple_get", new EchoRequestBody() }
              //add route and handler here
              // create new handler
            };
        return resourceHandlerDictionary;
    }

    private bool IsHttpMethodAllowed(Request requestObject)
    {
        IHandler handler = ResourceHandlerDictionary()[requestObject.GetRequestPath()];
        return handler.AllowedHttpMethods().Contains(requestObject.GetRequestMethod());
    }
}
// Dictionary<string, Dictionary<string, string>> info =
//     new Dictionary<string, Dictionary<string, string>>
//     {
//         {
//             "POST",
//             new Dictionary<string, string>
//             {
//                 { "/echo_body", new },
//             }
//         },
//         {
//             "GET",
//             new Dictionary<string, string>
//             {
//                 { "/simple_get", Controller.SimpleGetNoBody() },
//                 { "/simple_get_with_body", Controller.CreateResponseForGetRequest() },
//             }
//         }
//     };
// return info;
