using AutoMapper;
using MediatR;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.UserRoles.Queries;

namespace UserManagement.Application.Services.UserRoles.Queries;

public class GetUserRoleByIdCommandHandler : IRequestHandler<GetUserRoleByIdQuery, GetUserRoleByIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetUserRoleByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetUserRoleByIdResponse> Handle(GetUserRoleByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var userRole = await _unitOfWork.UserRoleRepository.GetUserRoleById(request.Query.Id);

            return new GetUserRoleByIdResponse(userRole.RoleId, userRole.UserId);

        }

        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}


