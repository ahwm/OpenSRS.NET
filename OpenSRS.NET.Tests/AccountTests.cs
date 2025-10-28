namespace OpenSRS.NET.Tests
{
    public class AccountTests(IDomainService domainService)
    {
        [Fact]
        public async Task GetBalance()
        {
            try
            {
                var balance = await domainService.GetBalance();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
