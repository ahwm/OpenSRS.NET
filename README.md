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
var resp = await client.RegisterAsync(new RegisterRequest { Domain = domain });
var resp = await client.LookupAsync(new LookupRequest(domain));
```

### .NET 8

Microsoft added support for using the HttpClient through dependency injection and this library takes advantage of that.

```csharp
// Program.cs

services.AddOpenSRS(_settings.Key, _settings.Username, _settings.IsTest);
```

```csharp
// controller
public class DomainController(OpenSRSClient openSrs) : Controller
{
    public async Task<IActionResult> RegisterDomain(string domain)
    {
        var resp = await openSrs.RegisterAsync(new RegisterRequest { Domain = domain });
    }

    public async Task<IActionResult> Lookup(string domain)
    {
        var resp = await openSrs.LookupAsync(new LookupRequest(domain));
    }
}
```
