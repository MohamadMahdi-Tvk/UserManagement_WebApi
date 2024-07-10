using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserManagement.DataAccess.Models;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public virtual string FullName => FirstName + " " + LastName;

    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;


    #region Navigation Properties

    public ICollection<Post> Posts { get; set; }

    public ICollection<UserRole> Users { get; set; }

    #endregion




}

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(p => p.Posts)
             .WithOne(p => p.User)
             .HasForeignKey(p => p.UserId);
    }
}

