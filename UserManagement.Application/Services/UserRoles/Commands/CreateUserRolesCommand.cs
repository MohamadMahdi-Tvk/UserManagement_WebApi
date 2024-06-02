using AutoMapper;
using MediatR;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.UserRoles.Commands;

namespace UserManagement.Application.Services.UserRoles.Commands;

public record CreateUserRolesCommand(CreateUserRoleRequest Command, CancellationToken CancellationToken) : IRequest<CreateUserRoleResponse>;

public class CreateUserRolesCommandHandler : IRequestHandler<CreateUserRolesCommand, CreateUserRoleResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserRolesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateUserRoleResponse> Handle(CreateUserRolesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userRole = _mapper.Map<CreateUserRoleRequest, UserRole>(request.Command);

            await _unitOfWork.UserRoleRepository.CreateRole(userRole);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateUserRoleResponse(IsSuccess: true);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

