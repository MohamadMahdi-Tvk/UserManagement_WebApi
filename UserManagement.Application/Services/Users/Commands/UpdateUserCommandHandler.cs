using AutoMapper;
using Dapper;
using MediatR;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Users.Commands;

namespace UserManagement.Application.Services.Users.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {

        try
        {
            var userUpdated = _mapper.Map<UpdateUserRequest, User>(request.Command);

            await _unitOfWork.UserRepository.UpdateUser(userUpdated);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UpdateUserResponse(IsSuccess: true);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

