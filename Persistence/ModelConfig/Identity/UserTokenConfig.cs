using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserTokenConfig : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable("UserTokens", "Identity");
        builder
            .HasKey(
            t => new { t.UserID }
            );

        builder
            .Property(t => t.UserID)
            .HasColumnName("User_ID");

        builder.Property(t => t.Value)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(t => t.User)
            .WithMany(u => u.Tokens)
            .HasForeignKey(d => d.UserID)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_UserToken_Users");
    }
}
