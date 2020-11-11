using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.AggregateModels.ProductAggregate
{
    public interface IProductUniquenessChecker
    {
        bool IsUnique(string productName);
    }
}
