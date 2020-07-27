using Microsoft.EntityFrameworkCore;
using Mine.Commerce.Domain;
using System.Linq;

namespace Mine.Commerce.Infrastructure.DBContext
{
    public class MineCommerceContext : DbContext
    {
        public MineCommerceContext(DbContextOptions<MineCommerceContext> options)
           : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(b => b.Brand);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(p => p.Category)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey( p => p.CategoryId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey( p => p.ProductId); 
                
            modelBuilder.Entity<ProductCategory>()
                .HasKey((o) => new {o.ProductId,o.CategoryId});      
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var markedAsDeleted = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);

            foreach (var item in markedAsDeleted)
            {
                if (item.Entity is Entity entity)
                {
                    // Set the entity to unchanged (if we mark the whole entity as Modified, every field gets sent to Db as an update)
                    item.State = EntityState.Unchanged;
                    // Only update the IsDeleted flag - only this will get sent to the Db
                    entity.IsDeleted = true;
                }
            }
            return base.SaveChanges();
        }
    }
}
