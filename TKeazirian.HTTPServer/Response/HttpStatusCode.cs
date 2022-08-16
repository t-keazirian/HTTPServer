namespace TKeazirian.HTTPServer.Response;

public enum HttpStatusCode
{
    Ok = 200,
    Created = 201,
    Moved = 301,
    BadRequest = 400,
    NotFound = 404,
    MethodNotAllowed = 405,
    UnsupportedMediaType = 415,
    NotImplemented = 501,
}
