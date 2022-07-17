using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RoleClaimConfig : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.ToTable("RoleClaim", "Identity");
        builder
            .HasKey(
            t => new { t.RoleID }
            );

        builder
            .Property(t => t.RoleID)
            .HasColumnName("Role_ID")
            .IsRequired();

        builder.Property(t => t.ClaimType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.ClaimValue)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(t => t.Role)
            .WithMany(u => u.Claims)
            .HasForeignKey(d => d.RoleID)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_RoleClaim_Roles");

            

    }
}
