using MediatR;
using UserManagement.DataAccess.ViewModels.UserRoles.Commands;

namespace UserManagement.Application.Services.UserRoles.Commands;

public record CreateUserRolesCommand(CreateUserRoleRequest Command, CancellationToken CancellationToken) : IRequest<CreateUserRoleResponse>;

