
using Application.Models;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.ProductQueries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IList<ProductDto>>
    {
        private readonly IDbConnection _connection;

        public GetAllProductsQueryHandler(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IList<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _connection.QueryAsync<ProductDto>(@"SELECT * FROM products");
            return products.ToList();
        }
    }
}
