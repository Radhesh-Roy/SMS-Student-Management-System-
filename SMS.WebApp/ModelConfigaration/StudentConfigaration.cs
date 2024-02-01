using Microsoft.EntityFrameworkCore;
using SMS.WebApp.Models;

namespace SMS.WebApp.ModelConfigaration
{
    public class StudentConfigaration : IEntityTypeConfiguration<Student>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(nameof(Student));
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(50).IsRequired();
            builder.Property(t => t.Address).HasMaxLength(250).IsRequired();
            builder.Property(t => t.Phone).HasMaxLength(15).IsRequired();
            builder.Property(t => t.Email).HasMaxLength(50).IsRequired();
            
        }
    }
}
