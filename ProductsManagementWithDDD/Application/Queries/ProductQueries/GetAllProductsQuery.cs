using Application.Models;
using MediatR;
using System.Collections.Generic;


namespace Application.Queries.ProductQueries
{
    public class GetAllProductsQuery: IRequest<IList<ProductDto>>
    {
        public GetAllProductsQuery() { }
    }
}
