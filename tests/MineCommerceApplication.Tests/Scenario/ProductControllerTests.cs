using MineCommerceApplication.Tests.Helper;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Mine.Commerce.Application.Products;
using System.Net.Http.Json;

namespace MineCommerceApplication.Tests.Scenario
{
    [Collection("CollectionFixture")]
    public class ProductControllerTests : IClassFixture<CollectionFixture>
    {
        private readonly CollectionFixture _fixture;
        private readonly HttpClient _httpClient;
        public ProductControllerTests(CollectionFixture fixture)
        {
            _fixture = fixture;
            _httpClient = _fixture.CreateClient();
            _httpClient.AppendJwtToken();
        }

        [Fact]
        public async Task GetListProductTestAsync()
        {
            var response = await _httpClient.GetAsync("/api/products");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async System.Threading.Tasks.Task CreateProductTestAsync()
        {
            var createRequest = new CreateRequest
            {
                Name = "Product 01",
            };
            var jsonContent = JsonContent.Create<CreateRequest>(createRequest);
            var response = await _httpClient.PostAsync("/api/products", jsonContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
