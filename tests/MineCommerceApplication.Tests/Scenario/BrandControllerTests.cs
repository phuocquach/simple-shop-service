using MineCommerceApplication.Tests.Helper;
using System.Threading.Tasks;
using System.Net.Http;
using Xunit;
using Mine.Commerce.Application.Brands;
using System.Net.Http.Json;
namespace MineCommerceApplication.Tests.Scenario
{
    [Collection("CollectionFixture")]
    public class BrandControllerTests : IClassFixture<CollectionFixture>
    {
        private readonly CollectionFixture _fixture;
        private readonly HttpClient _httpClient;
        public BrandControllerTests(CollectionFixture fixture)
        {
            _fixture = fixture;
            _httpClient = _fixture.CreateClient();
            _httpClient.AppendJwtToken();
        }

        [Fact]
        public async System.Threading.Tasks.Task GetListBrandTestAsync()
        {
            var response = await _httpClient.GetAsync("/api/brands");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CreateBrandTestAsync()
        {
            var createRequest = new CreateRequest
            {
                Name = "Brand 01",
                Country = "Country 01"
            };
            var jsonContent = JsonContent.Create<CreateRequest>(createRequest);
            var response = await _httpClient.PostAsync("/api/brands", jsonContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
