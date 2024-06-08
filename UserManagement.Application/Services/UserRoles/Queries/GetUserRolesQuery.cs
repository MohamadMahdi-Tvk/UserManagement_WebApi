using MediatR;
using UserManagement.DataAccess.ViewModels.UserRoles.Queries;

namespace UserManagement.Application.Services.UserRoles.Queries;

public record GetUserRolesQuery(CancellationToken CancellationToken) : IRequest<List<GetUserRolesResponse>>;

