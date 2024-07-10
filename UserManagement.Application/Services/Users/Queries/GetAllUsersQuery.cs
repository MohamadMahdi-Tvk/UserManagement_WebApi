using MediatR;
using UserManagement.DataAccess.ViewModels.Users.Queries;

namespace UserManagement.Application.Services.Users.Queries;

public record GetAllUsersQuery(GetAllUsersRequest Query, CancellationToken CancellationToken) : IRequest<Paginated<GetAllUsersResponse>>;
