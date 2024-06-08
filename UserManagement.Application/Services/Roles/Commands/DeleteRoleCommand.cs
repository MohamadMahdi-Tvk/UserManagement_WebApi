using MediatR;
using UserManagement.DataAccess.ViewModels.Roles.Commands;

namespace UserManagement.Application.Services.Roles.Commands;

public record DeleteRoleCommand(DeleteRoleRequest Command, CancellationToken CancellationToken) : IRequest<DeleteRoleResponse>;

