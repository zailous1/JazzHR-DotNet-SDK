<!-- Copyright (c) 2023 Zailous LLC -->

JazzHR-DotNET-SDK
=============

## Unofficial C# .NET SDK for JazzHR

**Note: This project is not affiliated with JazzHR or its parent company Employ, Inc. in any way. Use at your own risk. YMMV. We make no guarantees of any kind.**

**License:** [![Apache 2](https://img.shields.io/badge/license-MIT-brightgreen)](https://opensource.org/license/mit/)  
**Support:** [![Help](https://img.shields.io/badge/Support-Zailous%20Developer-blue.svg)](https://zailous.com/contact)  
**Binaries:** [![Nuget](https://img.shields.io/badge/Nuget-Package-blue.svg)](https://www.nuget.org/packages/JazzHR-DotNET-SDK/)

The JazzHR .NET SDK provides class libraries for accessing the JazzHR V1 API quickly, easily, and with confidence.
It supports .Net 7.0.

Some of the features include:

* Filter objects for targeting queries.
* Full asynchronous method support (async/await).
* Support for JSON request and response formats.
* Auto-paging for the simple retrieval of entities spanning multiple pages.
* Common logging framework to support a variety of providers, e.g. Serilog, log4net, nlog, etc.

## Documentation:
[API Reference](http://www.resumatorapi.com/v1/)

## Get Started:
1. Clone this repo locally
2. Open the JazzHR-DotNET-SDK.sln solution file in your .NET IDE of choice.
3. Review the unit tests.

## Example:
```csharp
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Zailous.JazzHR;
using Zailous.JazzHR.Models;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new JazzHRApiClient(
                "<YOUR_API_KEY>",
                LoggerFactory.Create(builder =>
                {
                    builder.AddConsole();
                }).CreateLogger<JazzHRApiClient>()
            );

            IEnumerable<User> users = await client.GetUsersAsync().ConfigureAwait(false);
        }
    }
}
```

## Contribution Guidelines:

Thank you for your interest in contributing to this project. You can report and fix existing bugs. Feel free to open issues and/or send pull requests.

- Before sending a PR, please discuss the issue with the project admins.
    - If the issue is not yet known, open a new issue and discuss.
    - Come to an agreement on the proposal before beginning work on the solution.

The `main` branch of this repository contains the latest stable release of the SDK. Pull requests should be submitted against `main` by forking this repo into your account, developing and testing your changes, and creating pull requests to request merges. See the [Contributing to a Project](https://guides.github.com/activities/contributing-to-open-source/)
article for more details about how to contribute.

### Steps to Contribute:

1. Fork this repository into your account on Github
2. Clone *your forked repository* (not our original one) down locally with `git clone https://github.com/YOURUSERNAME/JazzHR-DotNET-SDK.git`
3. Develop and validate your changes
5. Create a pull request for review to request merge
6. Obtain approval in order to have your changes merged

Note: Before you submit the pull request, make sure to remove the keys and tokens from appsettings.json

### Steps to Build and Validate Changes
1. Clone your forked repository (as above)
2. Make your changes
3. Build the solution
4. Confirm all unit tests pass
4. Fix any static code analysis errors
5. Validate StyleCop compliance (see stylecop.readme.txt for configuration).

Thank you for your contribution!