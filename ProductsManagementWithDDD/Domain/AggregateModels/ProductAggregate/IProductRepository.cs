using Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.AggregateModels.ProductAggregate
{
    public interface IProductRepository: IRepository<Product>
    {
    }
}
