# OpenSRS.NET

[![build](https://github.com/ahwm/OpenSRS.NET/actions/workflows/build.yml/badge.svg)](https://github.com/ahwm/OpenSRS.NET/actions/workflows/build.yml)

Fully operational API client for OpenSRS

Leading libraries lack a lot of functionality. Some of the base implementation inspired by/borrowed from [OpenSrs](https://github.com/carbon/OpenSrs).

Full domains API documentation here: http://domains.opensrs.guide/docs

## Usage

The usage differs slightly between .NET Framework and .NET 8.

### .NET Framework

Usage for .NET Framework and .NET versions < 8

```csharp
var client = new OpenSRSClient("apiKey", "username", test: true);
var resp = await client.RegisterAsync(request);
```

### .NET 8

Microsoft added support for using the HttpClient through dependency injection and this library takes advantage of that.

```csharp
// Program.cs

services.UseOpenSRS();
```

```csharp
// controller
public class DomainController : Controller
{
    private readonly OpenSRSClient _openSrs;
    public Controller(OpenSRSClient openSrs)
    {
        _openSrs = openSrs;
        _openSrs.Configure("apiKey", "username", test: true);
    }
    public async Task<IActionResult> RegisterDomain(object model)
    {
        var resp = await _openSrs.RegisterAsync(request);
    }
}
```
