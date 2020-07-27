using Microsoft.EntityFrameworkCore;
using Mine.Commerce.Domain;
using Moq;

namespace MineCommerceApplication.Tests.Helper
{
    public class MockDbContext : Mock<DbContext>
    {
        public Mock<DbSet<Category>> DbsetCategoryMock;
        public Mock<DbSet<Product>> DbsetProductMock;
        public Mock<DbSet<Brand>> DbsetBrandMock;

        public MockDbContext()
        {
            DbsetCategoryMock = new Mock<DbSet<Category>>();
            DbsetProductMock = new Mock<DbSet<Product>>();
            DbsetBrandMock = new Mock<DbSet<Brand>>();
        }
        
        
    }
}