using AutoMapper;
using MediatR;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Users.Commands;
using UserManagement.DataAccess.ViewModels.Users.Queries;

namespace UserManagement.Application.Services.Users.Commands;

public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdCommand, GetUserByIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByIdCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetUserByIdResponse> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = _mapper.Map<GetUserByIdRequest, User>(request.Command);

           return await _unitOfWork.UserRepository.GetUserById(request.Command.Id);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
}
