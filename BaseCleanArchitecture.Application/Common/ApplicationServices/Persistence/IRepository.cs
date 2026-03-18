namespace BaseCleanArchitecture.Application.Common.ApplicationServices.Persistence;

using Ardalis.Specification;

using BaseCleanArchitecture.Domain.Common;


public interface IRepository<TEntity> : IRepositoryBase<TEntity>
    where TEntity : BaseEntity
{
    Task SoftDeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
}
