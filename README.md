# OpenSRS.NET

Fully operational API client for OpenSRS

Leading libraries lack a lot of functionality. Some of the base implementation inspired by/borrowed from [OpenSrs](https://github.com/carbon/OpenSrs).

Full domains API documentation here: http://domains.opensrs.guide/docs

## Usage

The usage differs slightly between .NET Framework and .NET 8.

### .NET Framework

Usage for .NET Framework and .NET versions < 8

```csharp

var client = new OpenSRSClient("", "", true);
var resp = await client.RegisterAsync(request);

```

### .NET 8

Microsoft added support for using the HttClient through dependency injection and this library takes advantage of that.

```csharp

// Program.cs

services.UseOpenSRS();

```

```csharp

// controller
public class Controller(OpenSRSClient openSrs)
{
    public async Task<IActionResult> RegisterDomain(object model)
    {
        var resp = await openSrs.RegisterAsync(request);
    }
}

```