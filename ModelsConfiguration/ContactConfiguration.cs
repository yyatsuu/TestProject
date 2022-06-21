using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Models;

namespace TestProject.ModelsConfiguration
{
  public class ContactConfiguration : IEntityTypeConfiguration<Contact>
  {
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
      builder.HasKey(con => con.Id);
      builder.Property(con => con.Id).ValueGeneratedOnAdd();

      builder.Property(con => con.FirstName).IsRequired();
      builder.Property(con => con.LastName).IsRequired();

      builder.Property(con => con.Email).IsRequired();
      builder.HasIndex(con => con.Email).IsUnique();

      builder.HasOne(con => con.Account)
             .WithMany(acc => acc.Contacts)
             .HasForeignKey(con => con.AccountId)
             .HasPrincipalKey(acc => acc.Id)
             .IsRequired();
    }
  }
}
