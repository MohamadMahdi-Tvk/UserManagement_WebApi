using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserManagement.DataAccess.Models;

public class UserRole : BaseEntity
{
    public User User { get; set; }
    public int UserId { get; set; }

    public Role Role { get; set; }
    public int RoleId { get; set; }
}

public class UserRoleConfiguration : BaseEntityConfiguration<UserRole>
{
    public override void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasOne(p => p.User)
            .WithMany(p => p.Users)
            .HasForeignKey(p => p.UserId);

        builder.HasOne(p => p.Role)
            .WithMany(p => p.Roles)
            .HasForeignKey(p => p.RoleId);
    }
}