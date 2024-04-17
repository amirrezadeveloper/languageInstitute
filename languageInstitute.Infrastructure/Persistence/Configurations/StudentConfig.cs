using languageInstitute.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace languageInstitute.Infrastructure.Persistence.Configurations;

public class StudentConfig : IEntityTypeConfiguration<Student>
{
    void IEntityTypeConfiguration<Student>.Configure(EntityTypeBuilder<Student> builder)
    {

        builder
            .HasKey(x => x.Id)
            .IsClustered()
            .HasName("PK_Base_Student");
        builder
             .Property(x => x.FullName)
             .IsRequired()
             .HasMaxLength(250);
    }
}
