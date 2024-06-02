using UserManagement.DataAccess.Models;

namespace UserManagement.DataAccess.ViewModels.UserRoles.Commands;

public record CreateUserRoleRequest(int userId, int roleId);

