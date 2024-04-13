using languageInstitute.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace languageInstitute.DatabaseConfigurations;

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
