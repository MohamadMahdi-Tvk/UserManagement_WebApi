﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserManagement.DataAccess.Models;

public class Role : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public ICollection<UserRole> Roles { get; set; }
}

public class RoleConfiguration : BaseEntityConfiguration<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        base.Configure(builder);
    }
}
