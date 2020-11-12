using Domain.AggregateModels.ProductAggregate;
using Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.ProductCommands
{
    //public class EditProductCommandHandler : IRequestHandler<EditProductCommand>
    //{
    //    private readonly IProductRepository _productRepository;
    //    private readonly IUnitOfWork _unitOfWork;

    //    public EditProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    //    {
    //        _productRepository = productRepository;
    //        _unitOfWork = unitOfWork;
    //    }

    //    public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
    //    {
    //        //var product = await _productRepository.GetSingleAsync()
    //    }
    //}
}
