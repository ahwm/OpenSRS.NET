using Moq;
using OpenSRS.NET.Actions;
using Microsoft.Extensions.Options;

namespace OpenSRS.NET.Tests;

public class OpenSRSClientTests
{
    private class TestOpenSRSClient : OpenSRSClient
    {
        public Mock<TestOpenSRSClient> Mock { get; } = new Mock<TestOpenSRSClient> { CallBase = true };


        public TestOpenSRSClient() : base(new HttpClient(), Options.Create(new OpenSRSClientOptions { Key = "testkey" }))
        {
            Mock.Setup(m => m.SendAsync(It.IsAny<OpenSRSRequest>()))
                .ReturnsAsync("mocked response");
        }

        private Task<string> SendAsync(OpenSRSRequest request)
        {
            return Mock.Object.SendAsync(request);
        }
    }

    [Fact]
    public async Task RegisterAsync_ReturnsParsedResult()
    {
        var client = new TestOpenSRSClient();
        var request = new RegisterRequest();
        var result = await client.RegisterAsync(request);
        Assert.IsType<RegisterResult>(result);
    }

    [Fact]
    public async Task LookupAsync_ReturnsParsedResult()
    {
        var client = new TestOpenSRSClient();
        var request = new LookupRequest("example.com");
        var result = await client.LookupAsync(request);
        Assert.IsType<LookupResult>(result);
    }

    [Fact]
    public async Task NameSuggestAsync_ReturnsParsedResult()
    {
        var client = new TestOpenSRSClient();
        var request = new NameSuggestRequest { Query = "example", Tlds = new[] { ".com" } };
        var result = await client.NameSuggestAsync(request);
        Assert.IsType<NameSuggestResult>(result);
    }

    [Fact]
    public async Task GetPriceAsync_ReturnsParsedResult()
    {
        var client = new TestOpenSRSClient();
        var request = new GetPriceRequest("example.com");
        var result = await client.GetPriceAsync(request);
        Assert.IsType<GetPriceResult>(result);
    }

    [Fact]
    public async Task GetOrderInfoAsync_ReturnsParsedResult()
    {
        var client = new TestOpenSRSClient();
        var request = new GetOrderInfoRequest { Id = 12345 };
        var result = await client.GetOrderInfoAsync(request);
        Assert.IsType<GetOrderInfoResult>(result);
    }

    [Fact]
    public async Task CreateDnsZoneAsync_ReturnsParsedResult()
    {
        var client = new TestOpenSRSClient();
        var request = new CreateDnsZoneRequest { Domain = "example.com" };
        var result = await client.CreateDnsZoneAsync(request);
        Assert.IsType<CreateDnsZoneResult>(result);
    }
}