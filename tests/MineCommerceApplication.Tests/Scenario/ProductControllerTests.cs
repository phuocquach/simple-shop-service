using MineCommerceApplication.Tests.Helper;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

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
    }
}
