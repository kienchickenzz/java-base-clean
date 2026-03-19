namespace BaseCleanArchitecture.Application.Features.V1.Products.Specs;

using Ardalis.Specification;

using BaseCleanArchitecture.Application.Features.V1.Products.Models.Responses;
using BaseCleanArchitecture.Application.Features.V1.Products.Queries.GetProducts;
using BaseCleanArchitecture.Domain.AggregatesModels.Products;


public sealed class GetProductsSpec : Specification<Product, ProductResponse>
{
    public GetProductsSpec(GetProductsQuery request)
    {
        // Search by keyword trong Name hoặc Description
        if (!string.IsNullOrWhiteSpace(request.Keyword))
        {
            Query.Where(p =>
                p.Name.Contains(request.Keyword) ||
                (p.Description != null && p.Description.Contains(request.Keyword)));
        }

        // Default ordering: mới nhất trước
        Query.OrderByDescending(p => p.CreatedOn);
    }
}
