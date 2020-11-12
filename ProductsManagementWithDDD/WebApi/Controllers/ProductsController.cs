using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Commands.ProductCommands;
using Application.Models;
using Application.Products;
using Application.Products.CreateProduct;
using Application.Queries.ProductQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Requests.Product;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;
        private Guid CurrentProductId;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProductDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }


        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateNewProduct(CreateProductRequest request)
        {
            var product = await _mediator.Send(new CreateProductCommand(request.ProductName, request.Quantity, request.Price));

            return Created(string.Empty, product);
        }

        [HttpGet("{productName}")]
        public async Task<IActionResult> GetProduct(string productName)
        {
            var product = await _mediator.Send(new GetProductByNameQuery(productName));
            return Ok(product);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(Guid productId, UpdateProductRequest request)
        {
            var result = await _mediator.Send(new EditProductCommand(productId, request.ProductName, request.Quantity, request.Price));
            return Ok(result);
        }
    }
}
