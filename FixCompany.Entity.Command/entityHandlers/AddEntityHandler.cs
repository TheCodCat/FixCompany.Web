using CSharpFunctionalExtensions;
using EF.Core.Repositories;
using EF.Core.Repositories.Extensions;
using FixCompany.Data.context;
using FixCompany.Entity.Command.entityHandlers;
using FixCompany.Entity.Command.entityRequest;
using MediatR;

namespace FixCompany.Entity.Command.entityHandlers;

public class AddEntityHandler : IRequestHandler<AddEntityRequest, IResult<Domain.models.Entity?>>
{
    private readonly IRepositoryFactory<FixCompanyContext>  _repositoryFactory;

    public AddEntityHandler(IRepositoryFactory<FixCompanyContext>  repositoryFactory)
    {
        _repositoryFactory = repositoryFactory;
    }
    public async Task<IResult<Domain.models.Entity?>> Handle(AddEntityRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var repos = _repositoryFactory.GetRepository<Domain.models.Entity>();
            var result = await repos.InsertAsync(request.Entity, cancellationToken);
            
            return Result.Success(result);
        }
        catch (Exception e)
        {
            return Result.Failure<Domain.models.Entity>(e.Message);
        }
    }
}