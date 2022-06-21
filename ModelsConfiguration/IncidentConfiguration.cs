using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Models;

namespace TestProject.ModelsConfiguration
{
  public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
  {
    public void Configure(EntityTypeBuilder<Incident> builder)
    {
      builder.HasKey(inc => inc.Name);
            builder.Property(inc => inc.Name).HasDefaultValueSql("GetDate()");

      builder.Property(inc => inc.Description).IsRequired();
    }

  }
}
