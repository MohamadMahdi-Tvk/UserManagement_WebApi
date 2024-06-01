using MediatR;
using UserManagement.DataAccess.ViewModels.Roles.Commands;

namespace UserManagement.Application.Services.Roles.Commands;

public record CreateRoleCommand(CreateRoleRequest Command, CancellationToken CancellationToken) : IRequest<CreateRoleResponse>;
