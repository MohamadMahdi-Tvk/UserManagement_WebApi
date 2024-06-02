using MediatR;
using UserManagement.DataAccess.ViewModels.Roles.Commands;

namespace UserManagement.Application.Services.Roles.Commands;

public record UpdateRoleCommand(UpdateRoleRequest Command, CancellationToken CancellationToken) : IRequest<UpdateRoleResponse>;
