using AutoMapper;
using UserManagement.DataAccess.Models;
using UserManagement.DataAccess.ViewModels.Users.Commands;

namespace UserManagement.Application.ExtentionMethods;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region User
        CreateMap<CreateUserRequest, User>().ReverseMap();
        #endregion

    }
}
