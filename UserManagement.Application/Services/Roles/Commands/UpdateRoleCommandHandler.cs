﻿using AutoMapper;
using MediatR;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Roles.Commands;

namespace UserManagement.Application.Services.Roles.Commands;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, UpdateRoleResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateRoleResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var roleMapped = _mapper.Map<UpdateRoleRequest, Role>(request.Command);

            var roleUpdated = _unitOfWork.RoleRepository.UpdateRole(roleMapped);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UpdateRoleResponse(IsSuccess: true);
        }

        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
