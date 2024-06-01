using MediatR;
using UserManagement.DataAccess.ViewModels.Users.Queries;

namespace UserManagement.Application.Services.Users.Commands;

public record GetUserByIdCommand(GetUserByIdRequest Command, CancellationToken CancellationToken) : IRequest<GetUserByIdResponse>;

