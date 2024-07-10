using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserManagement.DataAccess.Models;

public class Post : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int UserId { get; set; }

    #region Navigation Properties

    public User User { get; set; }


    #endregion
}

public class PostConfiguration : BaseEntityConfiguration<Post>
{
    public override void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Property(p => p.Title).HasMaxLength(40);
        builder.Property(p => p.Description).HasMaxLength(10000);

            
    }
}
