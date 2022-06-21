using Microsoft.EntityFrameworkCore;
using TestProject.Models;
using TestProject.ModelsConfiguration;

namespace TestProject
{
  public class Context : DbContext
  {
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Incident> Incidents { get; set; }

    public Context()
    {
      Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=testDb; Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfiguration(new ContactConfiguration());
      builder.ApplyConfiguration(new AccountConfiguration());
      builder.ApplyConfiguration(new IncidentConfiguration());
    }
  }
}
