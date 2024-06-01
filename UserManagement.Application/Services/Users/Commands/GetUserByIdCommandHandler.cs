using MediatR;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Users.Queries;

namespace UserManagement.Application.Services.Users.Commands;

public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdCommand, GetUserByIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetUserByIdCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<GetUserByIdResponse> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = _unitOfWork.UserRepository.GetUserById(request.Command.Id);

            return user;

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

    }
}
