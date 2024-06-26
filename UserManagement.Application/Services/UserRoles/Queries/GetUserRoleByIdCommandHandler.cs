﻿using AutoMapper;
using Dapper;
using MediatR;
using System.Data;
using UserManagement.DataAccess.Models;
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
            //var userRole = await _unitOfWork.UserRoleRepository.GetUserRoleById(request.Query.Id);

            //var userRoleMapped = _mapper.Map<UserRole,GetUserRoleByIdResponse>(userRole);

            //return userRoleMapped;

            var parameters = new DynamicParameters();
            parameters.Add("Id", request.Query.Id);

            var userRole = await _unitOfWork.ApplicationReadDbConnection.QueryFirstAsync<GetUserRoleByIdResponse>("GetUserRoleById", parameters, null, CommandType.StoredProcedure, cancellationToken);

            return userRole;

        }

        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}


