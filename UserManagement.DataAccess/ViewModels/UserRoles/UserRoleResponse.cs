using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.DataAccess.ViewModels.UserRoles;

public record UserRoleResponse(int Id, string RoleTitle, string UserTitle);