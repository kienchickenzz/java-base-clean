using BaseCleanArchitecture.Application.Common.Mappings;
using BaseCleanArchitecture.Domain.Entities;

namespace BaseCleanArchitecture.Application.Features.Products;

public class ProductDto : IMapFrom<Product>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
