namespace OpenSRS.NET.Tests
{
    public class DomainTests
    {
        private readonly IDomainService _domainService;

        public DomainTests(IDomainService domainService)
        {
            _domainService = domainService;
        }

        //[Fact]
        //public async Task Register()
        //{
        //    await _domainService.Register("test.com");
        //}

        [Fact]
        public async Task Lookup()
        {
            try
            {
                await _domainService.CheckAvailable("test.com");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}