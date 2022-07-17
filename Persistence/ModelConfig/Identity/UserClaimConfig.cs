using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserClaimConfig : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable("UserClaim", "Identity");
        builder
             .HasKey(
             t => new { t.UserID }
             );

        builder
            .Property(t => t.UserID)
            .HasColumnName("User_ID");

        builder.Property(t => t.ClaimType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.ClaimValue)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(t => t.User)
            .WithMany(u => u.Claims)
            .HasForeignKey(d => d.UserID)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_UserClaim_Users");

    }
}
