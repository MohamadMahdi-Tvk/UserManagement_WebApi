using AutoMapper;
using Dapper;
using MediatR;
using System.Data;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Roles.Queries;

namespace UserManagement.Application.Services.Roles.Queries;

public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<GetRolesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetRolesResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            //var roles = await _unitOfWork.RoleRepository.GetAllRoles();

            //var rolesMapped = _mapper.Map<List<Role>, List<GetRolesResponse>>(roles);

            //return rolesMapped;

            var parameter = new DynamicParameters();
            var roles = await _unitOfWork.ApplicationReadDbConnection.QueryAsync<GetRolesResponse>("GetRoles", parameter, null, CommandType.StoredProcedure, cancellationToken);

            return roles;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

}

