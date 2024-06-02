using AutoMapper;
using MediatR;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.UserRoles.Commands;

namespace UserManagement.Application.Services.UserRoles.Commands;

public class UpdateUserRolesCommandHandler : IRequestHandler<UpdateUserRolesCommand, UpdateUserRoleResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateUserRolesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateUserRoleResponse> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var oldEntity = await _unitOfWork.UserRoleRepository.GetUserRoleById(request.Command.Id);

            _mapper.Map<UpdateUserRoleRequest, UserRole>(request.Command, oldEntity);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UpdateUserRoleResponse(IsSuccess: true);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

