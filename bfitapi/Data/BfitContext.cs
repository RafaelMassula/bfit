using bfitapi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Data
{
    public class BfitContext : DbContext
    {
        public BfitContext()
        {

        }
        public DbSet<TypePlan> TypesPlans { get; set; }
        public DbSet<PaymentType> TypesPayments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Product_Ingredient> Product_Ingredients { get; set; }

        public BfitContext(DbContextOptions<BfitContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product_Ingredient>()
                .HasKey(productingredient => new { productingredient.ProductId, productingredient.IngredientId });
        }
    }
}
