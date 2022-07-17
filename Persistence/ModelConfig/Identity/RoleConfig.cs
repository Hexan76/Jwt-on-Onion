using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public virtual void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles", "Identity");

        builder.HasKey(x => x.ID)
            .IsClustered();

        builder.Property(x => x.RoleName)
            .HasMaxLength(50);
        builder.Property(x => x.Description)
            .HasMaxLength(256);

    }
}
