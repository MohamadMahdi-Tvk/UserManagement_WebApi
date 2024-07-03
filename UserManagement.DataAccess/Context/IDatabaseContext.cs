using Microsoft.EntityFrameworkCore;
using System.Data;
using UserManagement.DataAccess.Models;

namespace UserManagement.DataAccess.Context
{
    public interface IDatabaseContext
    {
        public IDbConnection Connection { get; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
