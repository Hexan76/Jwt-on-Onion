using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "Identity");
        builder
            .HasKey(x => x.ID)
            .IsClustered();

        builder.Property(x => x.UserName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(256);
        builder.Property(x => x.Email)
            .HasMaxLength(100);
        builder.Property(x => x.EmailConfirm)
            .HasMaxLength(20);
        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20);
        builder.Property(x => x.PhoneNumberConfirm)
            .HasMaxLength(20);


        builder.HasMany(d => d.Roles)
    .WithMany(p => p.Users)
    .UsingEntity<Dictionary<string, object>>(
        "UserRole",
        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleID").OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_UserRole_Roles"),
        r => r.HasOne<User>().WithMany().HasForeignKey("UserID").OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_UserRole_Users"),
        j =>
        {
            j.HasKey("UserID", "RoleID");

            j.ToTable("UserRole", "Identity");
            j.IndexerProperty<Guid>("UserID").HasColumnName("User_ID");


            j.IndexerProperty<Guid>("RoleID").HasColumnName("Role_ID");
        });

        // builder
        // .HasMany(x => x.Claims)
        // .WithOne(x => x.User)
        // .HasForeignKey("User_ID");



    }
}
