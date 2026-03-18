using AutoMapper;
using BaseCleanArchitecture.Domain.Entities;
using BaseCleanArchitecture.Domain.Interfaces;
using MediatR;

namespace BaseCleanArchitecture.Application.Features.Common.Commands;

public record CreateCommand<TEntity, TDto>(TDto Data) : IRequest<TDto>
    where TEntity : BaseEntity;

public class CreateCommandHandler<TEntity, TDto> : IRequestHandler<CreateCommand<TEntity, TDto>, TDto>
    where TEntity : BaseEntity
{
    private readonly IRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public CreateCommandHandler(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TDto> Handle(CreateCommand<TEntity, TDto> request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TEntity>(request.Data);
        entity.Id = Guid.NewGuid();

        var created = await _repository.AddAsync(entity, cancellationToken);
        return _mapper.Map<TDto>(created);
    }
}
