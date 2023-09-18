using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Capstone1.Data
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Uses Lorem Picsum for example images. Website: https://picsum.photos/.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            const int amountOfProductsToSeed = 3;

            var productsToSeed = new Product[amountOfProductsToSeed];

            productsToSeed[0] = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Private Piano Lessons (0 to 4 Years)",
                Description = "Private Panio Lessons",
                Price = 18,

            };

            productsToSeed[1] = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Title = "PreSchool Piano Foundation (2 to 4 Years)",
                Description = "PreSchool Piano Foundation",
                Price = 18,

            };

            productsToSeed[2] = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Early Years Music",
                Description = "Early Years Music",
                Price = 18,

            };
            modelBuilder.Entity<Product>().HasData(productsToSeed);
        }
    }
}
