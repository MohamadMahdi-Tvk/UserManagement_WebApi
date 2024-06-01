using AutoMapper;
using MediatR;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Roles.Commands;

namespace UserManagement.Application.Services.Roles.Commands;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CreateRoleResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateRoleResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var role = _mapper.Map<CreateRoleRequest, Role>(request.Command);

            await _unitOfWork.RoleRepository.AddRole(role);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateRoleResponse(IsSuccess: true);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        };
    }
}