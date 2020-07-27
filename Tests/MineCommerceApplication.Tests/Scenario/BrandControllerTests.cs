using Microsoft.EntityFrameworkCore;
using Mine.Commerce.Domain;
using MineCommerceApplication.Tests.Helper;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;
using System.Threading;

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
    }
}
