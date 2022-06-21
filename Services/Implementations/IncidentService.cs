using TestProject.Models;
using TestProject.Models.DTO;
using TestProject.Services.Interfaces;

namespace TestProject.Services.Implementations
{
  public class IncidentService : IIncidentService
  {

    private readonly IAccountService accountService;
    private readonly Context context;

    public IncidentService(IAccountService accountService, Context context)
    {
      this.accountService = accountService;
      this.context = context;
    }

    public async Task<Incident> AddIncidentAsync(AddIncidentDTO incident)
    {
      Incident addedIncident = new()
      {
        Description = incident.Description,
      };

      await context.Incidents.AddAsync(addedIncident);
      await context.SaveChangesAsync();

      var temp = new AddAccountDTO()
      {
        Name = incident.Name,
        FirstName = incident.FirstName,
        LastName = incident.LastName,
        Email = incident.Email,
      };
      Account account = await accountService.AddAccountAsync(temp, addedIncident.Name);

      addedIncident.Accounts.Add(account);

      await context.SaveChangesAsync();

      return addedIncident;
    }
  }
}
