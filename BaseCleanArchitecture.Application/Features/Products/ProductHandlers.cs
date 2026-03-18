using AutoMapper;
using BaseCleanArchitecture.Application.Features.Common.Commands;
using BaseCleanArchitecture.Application.Features.Common.Queries;
using BaseCleanArchitecture.Domain.Entities;
using BaseCleanArchitecture.Domain.Interfaces;

namespace BaseCleanArchitecture.Application.Features.Products;

// MediatR cần concrete handlers cho mỗi entity type
// Các handlers này kế thừa từ generic handlers

public class GetAllProductsHandler : GetAllQueryHandler<Product, ProductDto>
{
    public GetAllProductsHandler(IRepository<Product> repository, IMapper mapper)
        : base(repository, mapper) { }
}

public class GetProductByIdHandler : GetByIdQueryHandler<Product, ProductDto>
{
    public GetProductByIdHandler(IRepository<Product> repository, IMapper mapper)
        : base(repository, mapper) { }
}

public class CreateProductHandler : CreateCommandHandler<Product, ProductDto>
{
    public CreateProductHandler(IRepository<Product> repository, IMapper mapper)
        : base(repository, mapper) { }
}

public class UpdateProductHandler : UpdateCommandHandler<Product, ProductDto>
{
    public UpdateProductHandler(IRepository<Product> repository, IMapper mapper)
        : base(repository, mapper) { }
}

public class DeleteProductHandler : DeleteCommandHandler<Product>
{
    public DeleteProductHandler(IRepository<Product> repository)
        : base(repository) { }
}
