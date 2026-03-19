namespace BaseCleanArchitecture.Application.Features.V1.Products.Queries.GetProductById;

using Ardalis.Specification;

using BaseCleanArchitecture.Application.Common.Messaging;
using BaseCleanArchitecture.Application.Common.ApplicationServices.Persistence;
using BaseCleanArchitecture.Application.Features.V1.Products.Models.Responses;
using BaseCleanArchitecture.Application.Features.V1.Products.Specs;
using BaseCleanArchitecture.Domain.AggregatesModels.Products;
using BaseCleanArchitecture.Domain.Common;


public sealed class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IProductRepository _productRepository;
    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<Result<ProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
        await _productRepository.FirstOrDefaultAsync(
            (ISpecification<Product, ProductResponse>)new ProductByIdSpec(request.Id), 
            cancellationToken) ?? 
        Result.Failure<ProductResponse>(ProductErrors.NotFound);
}
