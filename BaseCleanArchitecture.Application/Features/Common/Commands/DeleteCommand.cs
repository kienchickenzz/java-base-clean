using BaseCleanArchitecture.Domain.Entities;
using BaseCleanArchitecture.Domain.Interfaces;
using MediatR;

namespace BaseCleanArchitecture.Application.Features.Common.Commands;

public record DeleteCommand<TEntity>(Guid Id) : IRequest<bool>
    where TEntity : BaseEntity;

public class DeleteCommandHandler<TEntity> : IRequestHandler<DeleteCommand<TEntity>, bool>
    where TEntity : BaseEntity
{
    private readonly IRepository<TEntity> _repository;

    public DeleteCommandHandler(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteCommand<TEntity> request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            return false;

        await _repository.DeleteAsync(request.Id, cancellationToken);
        return true;
    }
}
