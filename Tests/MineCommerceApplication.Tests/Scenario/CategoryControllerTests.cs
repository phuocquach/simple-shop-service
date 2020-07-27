using MineCommerceApplication.Tests.Helper;
using System;
using System.Net.Http;
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
            var response = await _httpClient.GetAsync("/api/brands");
            response.EnsureSuccessStatusCode();
        }
    }
}
