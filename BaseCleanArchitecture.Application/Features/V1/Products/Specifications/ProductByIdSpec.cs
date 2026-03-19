namespace BaseCleanArchitecture.Application.Features.V1.Products.Specs;

using Ardalis.Specification;

using BaseCleanArchitecture.Application.Features.V1.Products.Models.Responses;
using BaseCleanArchitecture.Domain.AggregatesModels.Products;


public sealed class ProductByIdSpec : Specification<Product, ProductResponse>
{
    public ProductByIdSpec(int id) =>
        Query
            .Where(p => p.Id == id);
}
