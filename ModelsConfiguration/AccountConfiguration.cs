using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Models;

namespace TestProject.ModelsConfiguration
{
  public class AccountConfiguration : IEntityTypeConfiguration<Account>
  {
    public void Configure(EntityTypeBuilder<Account> builder)
    {
      builder.HasKey(acc => acc.Id);
      builder.Property(acc => acc.Id).ValueGeneratedOnAdd();

      builder.Property(acc => acc.Name).IsRequired();
      builder.HasIndex(acc => acc.Name).IsUnique();

      builder.HasOne(acc => acc.Incident)
             .WithMany(inc => inc.Accounts)
             .HasForeignKey(acc => acc.IncidentName)
             .HasPrincipalKey(inc => inc.Name)
             .IsRequired();
    }
  }
}
