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
        public DbSet<TypePayment> TypesPayments { get; set; }
        public BfitContext(DbContextOptions<BfitContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TypePayment>().HasKey(typePayment => typePayment.Id);
        }
    }
}
