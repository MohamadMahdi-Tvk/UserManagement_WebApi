using AutoMapper;
using Dapper;
using MediatR;
using System.Data;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.UserRoles.Queries;

namespace UserManagement.Application.Services.UserRoles.Queries;

public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, List<GetUserRolesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetUserRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetUserRolesResponse>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            //var userRoles = await _unitOfWork.UserRoleRepository.GetAllUserRoles();

            //return userRoles;


            var parameters = new DynamicParameters();

            var userRole = await _unitOfWork.ApplicationReadDbConnection.QueryAsync<GetUserRolesResponse>("GetUserRoles", parameters, null, CommandType.StoredProcedure, cancellationToken);

            return userRole;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}

