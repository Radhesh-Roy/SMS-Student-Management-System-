using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.WebApp.Models;

namespace SMS.WebApp.ModelConfigaration;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable(nameof(Teacher));
        builder.HasKey(x => x.Id);  
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Address).HasMaxLength(150).IsRequired();
        builder.Property(x => x.Phone).HasMaxLength(15).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Qualification).HasMaxLength(100).IsRequired();
      
    }
}
