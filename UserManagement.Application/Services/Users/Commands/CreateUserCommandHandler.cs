using AutoMapper;
using MediatR;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.UnitOfWork;
using UserManagement.DataAccess.ViewModels.Users.Commands;

namespace UserManagement.Application.Services.Users.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            //var newEntity = new User()
            //{
            //    FirstName = request.Command.FirstName,
            //    LastName = request.Command.LastName,
            //    UserName = request.Command.UserName,
            //    Password = request.Command.Password,
            //};

            var model = _mapper.Map<CreateUserRequest, User>(request.Command);


            var userRole = new UserRole
            {
                User = model,

                UserId = model.Id,

                RoleId = request.Command.RoleId
                
            };

            await _unitOfWork.UserRoleRepository.CreateRole(userRole);

            await _unitOfWork.UserRepository.AddUser(model);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateUserResponse(IsSuccess: true);
        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
