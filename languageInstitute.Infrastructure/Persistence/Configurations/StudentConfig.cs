using languageInstitute.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace languageInstitute.Infrastructure.Persistence.Configurations;

public class ClassConfig : IEntityTypeConfiguration<Class>
{
    void IEntityTypeConfiguration<Class>.Configure(EntityTypeBuilder<Class> builder)
    {

        builder
            .HasKey(x => x.Id)
            .IsClustered()
            .HasName("PK_Base_Student");
        builder
             .Property(x => x.ClassName)
             .IsRequired()
             .HasMaxLength(250);
    }
}
