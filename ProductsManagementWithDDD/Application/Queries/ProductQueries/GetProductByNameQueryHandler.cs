using Application.Models;
using Application.Products;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.ProductQueries
{
    public class GetProductByNameQueryHandler : IRequestHandler<GetProductByNameQuery, ProductDto>
    {
        private readonly IDbConnection _connection;

        public GetProductByNameQueryHandler(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<ProductDto> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var product = await _connection.QueryFirstAsync<ProductDto>(@"SELECT * FROM Products WHERE product_name = @ProductName", new { ProductName = request.ProductName});
            return product;
        }
    }
}
