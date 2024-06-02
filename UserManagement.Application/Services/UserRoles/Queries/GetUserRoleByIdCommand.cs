using AutoMapper;
using MediatR;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.UserRoles.Queries;

namespace UserManagement.Application.Services.UserRoles.Queries;

public record GetUserRoleByIdCommand(GetUserRoleByIdRequest Command, CancellationToken CancellationToken) : IRequest<GetUserRoleByIdResponse>;

public class GetUserRoleByIdCommandHandler : IRequestHandler<GetUserRoleByIdCommand, GetUserRoleByIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetUserRoleByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetUserRoleByIdResponse> Handle(GetUserRoleByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userRoleMapped = _mapper.Map<GetUserRoleByIdRequest, UserRole>(request.Command);

            var userRole = await _unitOfWork.UserRoleRepository.GetUserRoleById(userRoleMapped.Id);

            return userRole;
        }

        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}


