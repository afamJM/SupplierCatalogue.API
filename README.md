# SupplierCatalogue.API

The API for the Hitched Supplier Catalogue is a RESTful web service allowing searching of
wedding suppliers in the Hitched database.

## Architecture

The Supplier Catalogue API is a RESTful API written in C# using .NET Core, ASP.NET Core
and ASP.NET Core MVC.  Data persistence is handled by the Mongo NoSQL database
and accessed using the MongoDB C# API.

For more information see:

* [The Microsoft .NET Core Guide](https://docs.microsoft.com/en-us/dotnet/articles/core/)
* [The Microsoft C# Guide](https://docs.microsoft.com/en-us/dotnet/articles/csharp/)
* [The Microsoft Introduction to ASP.NET Core](https://docs.microsoft.com/en-gb/aspnet/core/)
* [The Microsoft Overview of ASP.NET Core MVC](https://docs.microsoft.com/en-gb/aspnet/core/mvc/overview)
* [The MongoDB Introduction to MongoDB](https://docs.mongodb.com/manual/introduction/)
* [The MongoDB C# and .NET MongoDB Driver Documentation](https://docs.mongodb.com/ecosystem/drivers/csharp/)

The API is designed to run on any operating system that supports .NET Core, including,
but not limited to :

*  Windows 10 (development only)
*  Windows Server 2012R2 or above
*  OS X
*  Ubuntu Linux (and other Linux distributions that support .NET Core)

The application is developed and tested on Intel x64 hardware, but should be architecture
independent and so should work on ARM7.

The API is designed to be run inside a Docker container if required.  See the  [Docker Overview](https://docs.docker.com/engine/understanding-docker/)
for more information.

The API is written in accordance with the [Immediate Platform Services Standards](https://tech.immediate.co.uk/confluence/display/PLATFORM/Services)
so that it conforms withthe requirements for Immediate Corporate APIs.

## Setting up a development environment

The requirements for a development environment for this project are:

* An IDE that understands C# and .NET Core
* The .NET Core SDK
* The Mongo noSQL database

### IDEs

#### Windows

In Windows, we suggest using either:

* [Visual Studio 2017](https://www.visualstudio.com/downloads/)
* [Visual Studio Code](https://code.visualstudio.com/download)

In Visual Studio you will need to select the .NET Core workload, plus any other workloads
that you may be interested in, when installing.  If you have an existing  installation,
you can add the .NET Core workload using the Visual Studio Installer.

For details of using C# and .NET Core in Visual Studio Code, see 
[Working with C#](https://code.visualstudio.com/docs/languages/csharp) in the Visual Studio 
Code microsite.

#### OS X

In OS X, we suggest using either:

* [Visual Studio Code](https://code.visualstudio.com/download)
* [Visual Studio for Mac](https://developer.xamarin.com/visual-studio-mac/)

For details of using C# and .NET Core in Visual Studio Code, see 
[Working with C#](https://code.visualstudio.com/docs/languages/csharp) on the Visual Studio 
Code website.

For details of using C# and .NET Core in Visual Studio Code, see 
[Getting Started with ASP.NET Core](https://developer.xamarin.com/guides/cross-platform/asp-net-core/)
on the Visual Studio for Mac website.

#### Linux

In Linux, we suggest using [Visual Studio Code](https://code.visualstudio.com/download). 
Details of using C# and .NET Core in Visual Studio Code are available in 
[Working with C#](https://code.visualstudio.com/docs/languages/csharp) on the Visual Studio
Code website.

### .NET Core

If you are using one of the IDEs listed above and follow the accompanying instructions
for enabling C# and .NET Core, you won't need to do anything extra to enable .NET Core.
If you are using a different development environment, instructions for installing .NET
Core are available for all supported operating systems at the 
[.NET Downloads](https://www.microsoft.com/net/download/core) .NET Core page on the 
Micorsoft website.

### MongoDB

Instructions for installing MongoDB are available on the 
[MongodB Community Edition Download](https://www.mongodb.com/download-center#community) page
on the MongoDB website.

###  Runtime Configuration

At runtime, the configuration of the API is controlled by a combination of two files 
and environment variable settings.  Each of these threee sources is merged and 
the merge result is what is used at runtime to opopulate the application configuration.
The sources are merged in the following order:

*  settings.json
*  settings.$\{APSNETCORE_ENVIRONMEMT\}.json
*  environment variables

For details on setting the ASPNET_ENVIRONMENT variable, see 
[Working with Multiple Environments](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments)
on the Microsoft website.

The configuration file is a json object as similar to:

```json
{
    "datastore": {
        "connection": "mongodb://localhost:27017",
        "database": "hitched"
    },
    "documentationPath": "./bin/Debug/netcoreapp1.1/SupplierCatalogue.API.xml"
}
```

but may contain significantly more values in practice.

The overriding file does not need to contain all the values in the main file, just the ones 
need to be overriden, so:

```json
{
    "datastore": {
        "connection": "mongodb://mymongoserver:27017",
}
```
would be sufficient to override the connection string for the datastore.

Environment variables are single values and so the name of the variable is
used to determine the structure.  The value key is seperated from the container
using a colon(':') or two underscore('__') characters and so:

```cli
datastore:connection=mongodb://myotherserver:27017
```

or

```cli
datastore__connection=mongodb://myotherserver:27017
```

would overide the datastore connection string. By convention, colon is used
unless the operating system does not allow colons in enviroment variable 
names.

## Docker Configuration
### Pre-Requisites
In order to use the Docker functionality please ensure you first [install Docker](https://docs.docker.com/engine/getstarted/step_one/) in your chosen development environment.

You can check everything is working correctly with the following command:
```cli
docker version
```

### Build the docker image

Navigate to the project folder (containing Dockerfile) and issue the following command to build a Docker image of the application:
```cli
docker build -t suppliercatalogue_api .
```
The command takes several seconds to run and reports its outcome.

### Run the docker image

Once the image has been built you can then run it with the following command:
```cli
docker run -p 8080:8080 suppliercatalogue_api
```
