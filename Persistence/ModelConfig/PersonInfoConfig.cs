using Data.MainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PersonInfoConfig : IEntityTypeConfiguration<PersonInfo>
{
    public void Configure(EntityTypeBuilder<PersonInfo> builder)
    {
        builder
            .HasKey(x => x.UserID)
            .IsClustered();
    }
}
