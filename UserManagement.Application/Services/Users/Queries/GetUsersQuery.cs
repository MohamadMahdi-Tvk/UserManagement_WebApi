using MediatR;
using UserManagement.DataAccess.ViewModels.Users.Queries;

namespace UserManagement.Application.Services.Users.Queries;

public record GetUsersQuery(CancellationToken CancellationToken) : IRequest<List<UsersResponse>>;
