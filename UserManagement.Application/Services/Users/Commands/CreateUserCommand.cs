using MediatR;
using UserManagement.DataAccess.ViewModels.Users.Commands;

namespace UserManagement.Application.Services.Users.Commands;

public record CreateUserCommand(CreateUserRequest Command, CancellationToken CancellationToken) : IRequest<CreateUserResponse>;

