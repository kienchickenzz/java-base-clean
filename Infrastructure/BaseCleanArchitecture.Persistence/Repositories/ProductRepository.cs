namespace BaseCleanArchitecture.Persistence.Repositories;

using BaseCleanArchitecture.Application.Common.ApplicationServices.Persistence;
using BaseCleanArchitecture.Domain.AggregatesModels.Products;
using BaseCleanArchitecture.Persistence.Common;


public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
