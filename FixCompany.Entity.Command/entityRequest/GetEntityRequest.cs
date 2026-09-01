using CSharpFunctionalExtensions;
using MediatR;

namespace FixCompany.Entity.Command.entityRequest;

public class GetEntityRequest : IRequest<IResult<IEnumerable<Domain.models.Entity>>>
{
    
}