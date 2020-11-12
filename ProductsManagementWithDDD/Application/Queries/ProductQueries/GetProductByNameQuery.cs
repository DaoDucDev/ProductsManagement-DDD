using Application.Models;
using Application.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.ProductQueries
{
    public class GetProductByNameQuery: IRequest<ProductDto>
    {
        public string ProductName { get; set; }

        public GetProductByNameQuery(string productName)
        {
            ProductName = productName;
        }
    }
}
