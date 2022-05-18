# Echo Server

This project is built in [C#][3] and [.NET][2].

.NET is a free, cross-platform, open source developer platform for building many different types of applications.

C# is a simple, modern, object-oriented, and type-safe programming language.

## Installation:

1. To download .NET Core, visit [this][4] website.
2. This project uses .NET version `6.0.202`. You can run the command `dotnet --version` to determine which version you have installed, or visit the .NET docs to install the correct version.

## [Description:][1]

### Functional Requirements

A user should be able to interact with the echo server as follows:

- When a client sends a message to the server, the server sends a response back to the client containing the original message.
- A client can send multiple messages to the server and get the echoed response back each time.
- Multiple clients can send messages to server and get back their proper responses.

### Implementation Requirements

- The server should establish a socket connection with the client using a low-level socket library. The goal of this exercise is to work with sockets directly.
- The server should accept and return streams of data rather than raw strings.
- The echo server should be covered by a robust suite of tests.

## To Run the App:

1. Ensure you are in the correct folder: `/echo-server/EchoServer.UI`
2. Type `dotnet run` in your command line prompt

**Alternatively**, you can run the app from the root directory with the command `dotnet run --project EchoServer.UI/EchoServer.UI.csproj`

## Testing:

This project uses xUnit.net for testing. Visit [this][5] website for more information and how to use xUnit.net.

### To Run the Tests:

1. Ensure you are in the correct folder: `/echo-server/EchoServer.Tests`
2. Type `dotnet test` in your command line prompt

**Alternatively**, you can run the tests from the root directory with the command `dotnet test EchoServer.Tests/EchoServer.Tests.csproj`

[1]: https://github.com/8thlight/apprenticeship_syllabus/blob/4ac3c45640ca506038cfe5cd0a8562a65634f8e7/shared_resources/projects/http_server/01_beginner/echo_server.md
[2]: https://dotnet.microsoft.com/en-us/learn/dotnet/what-is-dotnet
[3]: https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/
[4]: https://dotnet.microsoft.com/en-us/download
[5]: https://xunit.net/
