namespace TKeazirian.HTTPServer.Utils;

public static class FileUtility
{
    public static string GetPath()
    {
        string path;
        var currentDirectory = Directory.GetCurrentDirectory();
        if (currentDirectory.Contains("/bin/Debug"))
        {
            string? parentDirectory = Directory.GetParent(currentDirectory)?.ToString();
            var workingDirectory = Directory.GetParent(parentDirectory ?? string.Empty);
            var projectDirectory = Directory.GetParent(workingDirectory?.ToString() ?? string.Empty);
            path = $"{projectDirectory}/http_server_spec/web/";
        }
        else
        {
            path = @"./http_server_spec/web/";
        }

        return path;
    }
}
