using AutoMapper;
using BaseCleanArchitecture.Domain.Entities;
using BaseCleanArchitecture.Domain.Interfaces;
using MediatR;

namespace BaseCleanArchitecture.Application.Features.Common.Queries;

public record GetAllQuery<TEntity, TDto>() : IRequest<IEnumerable<TDto>>
    where TEntity : BaseEntity;

public class GetAllQueryHandler<TEntity, TDto> : IRequestHandler<GetAllQuery<TEntity, TDto>, IEnumerable<TDto>>
    where TEntity : BaseEntity
{
    private readonly IRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public GetAllQueryHandler(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TDto>> Handle(GetAllQuery<TEntity, TDto> request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<TDto>>(entities);
    }
}
