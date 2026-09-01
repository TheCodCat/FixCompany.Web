using CSharpFunctionalExtensions;
using MediatR;

namespace FixCompany.Entity.Command.entityRequest;

public class AddEntityRequest : IRequest<IResult<Domain.models.Entity?>>
{
    public readonly Domain.models.Entity Entity;
    
    public AddEntityRequest(Domain.models.Entity entity)
    {
      Entity = entity;
    }
}