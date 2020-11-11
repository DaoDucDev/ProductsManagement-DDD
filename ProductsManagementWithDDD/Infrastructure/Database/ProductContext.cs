using Domain.AggregateModels.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database
{
    public class ProductContext: DbContext
    {
        public virtual DbSet<Product> products { get; set; }
       
        public ProductContext(DbContextOptions<ProductContext> options) : base (options)
        {

        }

        public ProductContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductContext).Assembly);
        }
    }
}
