using AutoMapper;
using BaseCleanArchitecture.Domain.Entities;
using BaseCleanArchitecture.Domain.Interfaces;
using MediatR;

namespace BaseCleanArchitecture.Application.Features.Common.Queries;

public record GetByIdQuery<TEntity, TDto>(Guid Id) : IRequest<TDto?>
    where TEntity : BaseEntity;

public class GetByIdQueryHandler<TEntity, TDto> : IRequestHandler<GetByIdQuery<TEntity, TDto>, TDto?>
    where TEntity : BaseEntity
{
    private readonly IRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public GetByIdQueryHandler(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TDto?> Handle(GetByIdQuery<TEntity, TDto> request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return entity is null ? default : _mapper.Map<TDto>(entity);
    }
}
