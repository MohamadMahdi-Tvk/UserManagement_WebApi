using MediatR;
using UserManagement.DataAccess.ViewModels.UserRoles.Commands;

namespace UserManagement.Application.Services.UserRoles.Commands;

public record UpdateUserRolesCommand(UpdateUserRoleRequest Command, CancellationToken CancellationToken) : IRequest<UpdateUserRoleResponse>;

