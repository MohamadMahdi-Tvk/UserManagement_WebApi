using MediatR;
using UserManagement.DataAccess.ViewModels.UserRoles.Queries;

namespace UserManagement.Application.Services.UserRoles.Queries;

public record GetUserRoleByIdQuery(GetUserRoleByIdRequest Query, CancellationToken CancellationToken) : IRequest<GetUserRoleByIdResponse>;


