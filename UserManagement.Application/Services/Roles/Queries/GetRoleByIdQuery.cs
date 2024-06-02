using MediatR;
using UserManagement.DataAccess.Repositories;
using UserManagement.DataAccess.ViewModels.Roles.Queries;

namespace UserManagement.Application.Services.Roles.Queries;

public record GetRoleByIdQuery(GetRoleByIdRequest Query, CancellationToken CancellationToken) : IRequest<GetRoleByIdResponse>;

