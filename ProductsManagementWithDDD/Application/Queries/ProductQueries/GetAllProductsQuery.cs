using Application.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.ProductQueries
{
    public class GetAllProductsQuery: IRequest<IList<ProductDto>>
    {
        public GetAllProductsQuery() { }
    }
}
