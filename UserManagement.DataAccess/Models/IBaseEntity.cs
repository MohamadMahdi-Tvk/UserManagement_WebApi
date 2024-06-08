using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserManagement.DataAccess.Models;

public interface IBaseEntity
{
    public int Id { get; set; }
    public DateTime InsertDate { get; set; }
    public string InsertedUser { get; set; }
    public bool IsDeleted { get; set; }
}

public class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    public DateTime InsertDate { get; set; } = DateTime.Now;
    public string InsertedUser { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
}

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(p => p.Id);
       
    }
}


