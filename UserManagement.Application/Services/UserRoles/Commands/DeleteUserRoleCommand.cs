using MediatR;
using UserManagement.DataAccess.ViewModels.UserRoles.Commands;

namespace UserManagement.Application.Services.UserRoles.Commands;

public record DeleteUserRoleCommand(DeleteUserRoleRequest Command, CancellationToken CancellationToken) : IRequest<DeleteUserRoleResponse>;

