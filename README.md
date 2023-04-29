# 
This project is a sample ASP.NET API project that demonstrates how to use EF Second Level Cache with Redis and InMemory cache providers and automate caching LINQ queries.

## Introduction
EF Second Level Cache is a library that provides caching for Entity Framework Core queries. This project demonstrates how to use EF Second Level Cache with Redis and InMemory cache providers and automate caching LINQ queries. Automating caching with the Cachable attribute enables us to cache LINQ queries without adding additional code to the controller method.

# Getting Started
## Prerequisites
To run this project, you will need to have .NET 5 installed on your machine. You can download it from the official .NET website: [https://dotnet.microsoft.com/download/dotnet/7.0](https://dotnet.microsoft.com/download/dotnet/7.0)

## Installation
To install the necessary dependencies for this project, open a command prompt or terminal window and navigate to the project directory. Then, run the following command:

```bash
dotnet restore
```

This will download and install all the required NuGet packages, including the necessary packages for EF Second Level Cache, Redis, and InMemory cache providers.

## Setting Up the Cache Providers
To use EF Second Level Cache with Redis and InMemory cache providers, you'll need to add the necessary configuration settings to the appsettings.json file. Here's an example configuration:

```bash
"CacheProvider": "redis", // or inmemory (or empty for value if you don't want to using cache provider)
"easycaching": {
    "redis": {
      "MaxRdSecond": 120,
      "EnableLogging": false,
      "LockMs": 5000,
      "SleepMs": 300,
      "dbconfig": {
        "Password": "eYVX7EwVmmxKPCDmwMtyKVge8oLd2t81",
        "IsSsl": false,
        "SslHost": null,
        "ConnectionTimeout": 5000,
        "AllowAdmin": true,
        "Endpoints": [
          {
            "Host": "localhost",
            "Port": 6379
          }
        ],
        "Database": 0
      }
    },
    "inmemory": {
      "MaxRdSecond": 120,
      "EnableLogging": false,
      "LockMs": 5000,
      "SleepMs": 300,
      "DBConfig": {
        "SizeLimit": 10000,
        "ExpirationScanFrequency": 60,
        "EnableReadDeepClone": true,
        "EnableWriteDeepClone": false
      }
    }
```

In this example, we're using Redis as the cache provider and specifying the Redis server's configuration and instance name. If you want to use InMemory as the cache provider, you can set "CacheProvider": "inmemory" instead.

# Usage
## Automating Caching with the Cachable Attribute
To automate caching of your LINQ queries, you can use the Cachable attribute on your API methods. Here's an example:

```bash
[HttpGet]
public async Task<ActionResult<IEnumerable<MyModel>>> Get()
{
    var models = await _applicationDbContext.Author.Cacheable().ToListAsync();
    return Ok(models);
}
```

In this example, we're using the Cachable attribute to cache the results of the Get method for 60 seconds. When a client requests this method, the API will first check the cache for cached data before executing the method. If the data is cached, the API will return the cached data. If the data is not cached, the API will execute the method and cache the results.

# Built With
ASP.NET Core - A cross-platform, high-performance, open-source framework for building modern, cloud-based, Internet-connected applications.
Entity Framework Core - A lightweight, extensible, open-source and cross-platform ORM for .NET.
EF Second Level Cache - 
InMemoryCache - An in-memory cache implementation provided by the ASP.NET Core framework.
Redis - A popular in-memory key-value data store.

# License
This project is licensed under the MIT License. See the LICENSE file for more information.

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
