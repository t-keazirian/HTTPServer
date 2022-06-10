# HTTP Server

This is an [8th Light][12] Apprenticeship project, built in [C#][3] and [.NET][2].

.NET is a free, cross-platform, open source developer platform for building many different types of applications.

C# is a simple, modern, object-oriented, and type-safe programming language.

## Installation:

1. To download .NET Core, click [here][4].
2. This project uses .NET version `6.0.202`

Run the command: 
```shell
dotnet --version
``` 
to determine which version you have installed, or visit the [.NET docs][11] for more information.

## [Project Description:][1]

- This project started off with a simple Echo Server, and has been built out into an HTTP Server.
- This HTTP server includes routes, requests, and responses.
- The routes must be customizable with a URL, a verb, and an action to take when the route is called.

## Functional Requirements

A user should be able to interact with the HTTP server as follows:

* When a client sends a properly formatted request to the server, the server sends an appropriate response back to the client.
* A client can send different HTTP requests to the server and get the appropriate response back each time.
* Different clients can send messages to server and get back their proper responses.
* The server should be able to handle 200, 300, and 400-level responses.

## Implementation Requirements

* The server should establish a socket connection with the client using a low-level socket library.
* The server should accept and return streams of data rather than raw strings.
* The HTTP server should be covered by a robust suite of unit tests.
* The HTTP server should pass all of the tests covered in `01_getting_started` in the [HTTP Server Spec](https://github.com/8thlight/http_server_spec).

<p align="right">(<a href="#top">back to top</a>)</p>

## To Run the App:

```shell 
dotnet run --project TKeazirian.HTTPServer
```

## Testing:

This project uses [xUnit.net][5] for testing.

This project also uses an [acceptance test suite][9] written using [Cucumber][10].

### Run the xUnit Test Suite:

```shell
dotnet test
```

### Acceptance Tests:
#### Setup

1. You will need [Ruby][6] version `2.5.1`.  You can install Ruby using [brew][7] or the Ruby [docs][8]. 
2. Once Ruby is installed, run `ruby -v` to confirm you are using the appropriate version.
3. Next, run `bundle install`.

### Run the Acceptance Tests
Note: This server is currently programmed to run on port `5000`. If you would like to change the port, you can change the value of the variable, `private static int _port = 5000` (line 11) in `Server.cs` and recompile. In the future, the goal is to make this customizable via a command-line argument.

1. Start your HTTP server (you can do this by running the `dotnet run --project TKeazirian.HTTPServer` command or click `Run` if you are using an IDE)
2. Navigate into the `http_server_spec` folder: `cd http_server_spec`
3. You can run the acceptance tests with:
```shell
rake test
```

Note: You can skip any of the acceptance tests by adding `@wip` to the test(s).

<p align="right">(<a href="#top">back to top</a>)</p>

[1]: https://github.com/8thlight/apprenticeship_syllabus/blob/4ac3c45640ca506038cfe5cd0a8562a65634f8e7/shared_resources/projects/http_server/01_beginner/echo_server.md
[2]: https://dotnet.microsoft.com/en-us/learn/dotnet/what-is-dotnet
[3]: https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/
[4]: https://dotnet.microsoft.com/en-us/download
[5]: https://xunit.net/
[6]: https://www.ruby-lang.org/en/
[7]: https://mac.install.guide/ruby/13.html
[8]: https://www.ruby-lang.org/en/documentation/installation/
[9]: https://github.com/8thlight/http_server_spec
[10]: https://cucumber.io/
[11]: https://docs.microsoft.com/en-us/dotnet/
[12]: https://8thlight.com/
