using UserManagement.DataAccess.Models;

namespace UserManagement.DataAccess.ViewModels.UserRoles.Commands;

public record UpdateUserRoleRequest(int Id, int RoleId, int UserId);

