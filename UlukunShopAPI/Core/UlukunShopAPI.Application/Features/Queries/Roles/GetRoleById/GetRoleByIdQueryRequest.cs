using MediatR;

namespace UlukunShopAPI.Application.Features.Queries.Roles.GetRoleById;

public class GetRoleByIdQueryRequest : IRequest<GetRoleByIdQueryResponse>
{
    public string Id { get; set; }
}