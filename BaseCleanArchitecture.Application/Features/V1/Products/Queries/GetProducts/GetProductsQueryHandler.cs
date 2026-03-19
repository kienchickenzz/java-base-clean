namespace BaseCleanArchitecture.Application.Features.V1.Products.Queries.GetProducts;

using BaseCleanArchitecture.Application.Common.Messaging;
using BaseCleanArchitecture.Application.Common.ApplicationServices.Persistence;
using BaseCleanArchitecture.Application.Common.Models;
using BaseCleanArchitecture.Application.Features.V1.Products.Models.Responses;
using BaseCleanArchitecture.Application.Features.V1.Products.Specs;
using BaseCleanArchitecture.Domain.Common;


public sealed class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, PaginationResponse<ProductResponse>>
{
    private readonly IProductRepository _productRepository;
    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<Result<PaginationResponse<ProductResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetProductsSpec(request);

        return
            await _productRepository.PaginatedListAsync(
                spec,
                request.PageNumber,
                request.PageSize,
                cancellationToken);
    }
}
