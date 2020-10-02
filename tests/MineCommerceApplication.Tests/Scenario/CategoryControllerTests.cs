using Mine.Commerce.Application.Categories;
using MineCommerceApplication.Tests.Helper;
using System.Net.Http;
using System.Net.Http.Json;
using Xunit;

namespace MineCommerceApplication.Tests.Scenario
{
    [Collection("CollectionFixture")]
    public class CategoryControllerTests : IClassFixture<CollectionFixture>
    {
        private readonly CollectionFixture _fixture;
        private readonly HttpClient _httpClient;
        public CategoryControllerTests(CollectionFixture fixture)
        {
            _fixture = fixture;
            _httpClient = _fixture.CreateClient();
            _httpClient.AppendJwtToken();
        }

        [Fact]
        public async System.Threading.Tasks.Task GetListCategoryTestAsync()
        {
            var response = await _httpClient.GetAsync("/api/categories");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async System.Threading.Tasks.Task CreateCategoryTestAsync()
        {
            var createRequest = new CreateRequest
            {
                Name = "Category 01",
            };
            var jsonContent = JsonContent.Create<CreateRequest>(createRequest);
            var response = await _httpClient.PostAsync("/api/categories", jsonContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
