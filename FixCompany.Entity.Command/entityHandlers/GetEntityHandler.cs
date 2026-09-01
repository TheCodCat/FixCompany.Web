using CSharpFunctionalExtensions;
using EF.Core.Repositories;
using EF.Core.Repositories.Extensions;
using FixCompany.Data.context;
using FixCompany.Entity.Command.entityRequest;
using MediatR;

namespace FixCompany.Entity.Command.entityHandlers;

public class GetEntityHandler : IRequestHandler<GetEntityRequest, IResult<IEnumerable<Domain.models.Entity>>>
{
    private readonly IRepositoryFactory<FixCompanyContext> _repositoryFactory;

    public GetEntityHandler(IRepositoryFactory<FixCompanyContext> repositoryFactory)
    {
        _repositoryFactory = repositoryFactory;
    }
    public async Task<IResult<IEnumerable<Domain.models.Entity>>> Handle(GetEntityRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var repos = _repositoryFactory.GetReadOnlyRepository<Domain.models.Entity>().Include(x => x.Role);
            var result = await repos.GetAsync(cancellationToken);
            return Result.Success(result);
        }
        catch (Exception e)
        {
            return Result.Failure<IEnumerable<Domain.models.Entity>>(e.Message);
        }
    }
}