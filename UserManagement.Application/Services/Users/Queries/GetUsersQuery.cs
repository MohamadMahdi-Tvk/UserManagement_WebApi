using MediatR;
using UserManagement.DataAccess.ViewModels.Users.Queries;

namespace UserManagement.Application.Services.Users.Queries;

public record GetUsersQuery(UsersRequest Query, CancellationToken CancellationToken) : IRequest<List<UsersResponse>>;
