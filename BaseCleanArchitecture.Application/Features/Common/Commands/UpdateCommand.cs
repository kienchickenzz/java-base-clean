using AutoMapper;
using BaseCleanArchitecture.Domain.Entities;
using BaseCleanArchitecture.Domain.Interfaces;
using MediatR;

namespace BaseCleanArchitecture.Application.Features.Common.Commands;

public record UpdateCommand<TEntity, TDto>(Guid Id, TDto Data) : IRequest<TDto?>
    where TEntity : BaseEntity;

public class UpdateCommandHandler<TEntity, TDto> : IRequestHandler<UpdateCommand<TEntity, TDto>, TDto?>
    where TEntity : BaseEntity
{
    private readonly IRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public UpdateCommandHandler(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TDto?> Handle(UpdateCommand<TEntity, TDto> request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
            return default;

        _mapper.Map(request.Data, entity);
        entity.Id = request.Id;

        await _repository.UpdateAsync(entity, cancellationToken);
        return _mapper.Map<TDto>(entity);
    }
}
