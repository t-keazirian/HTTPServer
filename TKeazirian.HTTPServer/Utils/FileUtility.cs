namespace TKeazirian.HTTPServer.Utils;

public static class FileUtility
{
    public static string GetPath()
    {
        string path = "";
        var currentDirectory = Directory.GetCurrentDirectory();
        if (currentDirectory == @"/Users/taylorkeazirian/Code/HTTPServer/TKeazirian.HTTPServer/bin/Debug/net6.0")
        {
            var workingDirectory = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString());
            var projectDirectory = Directory.GetParent(workingDirectory.ToString());
            path = $"{projectDirectory}/http_server_spec/web/";
        }
        else
        {
            path = @"./http_server_spec/web/";
        }

        return path;
    }
}
