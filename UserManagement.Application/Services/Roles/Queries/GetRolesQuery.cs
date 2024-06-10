using MediatR;
using UserManagement.DataAccess.ViewModels.Roles.Queries;

namespace UserManagement.Application.Services.Roles.Queries;

public record GetRolesQuery(CancellationToken CancellationToken) : IRequest<List<GetRolesResponse>>;

