using Application.Commands;
using Domain.AggregateModels.ProductAggregate;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.CreateProduct
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        //private readonly IProductUniquenessChecker _productUniquenessChecker;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDto> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product(command.ProductName, command.Quantity, command.Price);
            _productRepository.Add(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new ProductDto { ProductId = product.ProductId};

        }
    }
}
