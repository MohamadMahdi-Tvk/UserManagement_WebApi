using MediatR;
using UserManagement.DataAccess.ViewModels.Users.Commands;

namespace UserManagement.Application.Services.Users.Commands;

public record UpdateUserCommand(UpdateUserRequest Command, CancellationToken cancellationToken) : IRequest<UpdateUserResponse>;

