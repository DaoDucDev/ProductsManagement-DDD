using Domain.AggregateModels.ProductAggregate;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Domain.Products
{
    public class ProductRepository :  Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductContext dbcontext): base(dbcontext)
        {

        }
        
    }
}
