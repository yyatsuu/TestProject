using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProject.Models;
using TestProject.Models.DTO;
using TestProject.Services.Interfaces;

namespace TestProject.Controllers
{
  [ApiController]
  public class ProjectController : ControllerBase
  {
    private readonly IAccountService accountService;
    private readonly IIncidentService incidentService;
    private readonly Context context;

    public ProjectController(IAccountService accountService, IIncidentService incidentService)
    {
      this.accountService = accountService;
      this.incidentService = incidentService;
    }

    [HttpPost("addContact")]
    public async Task<ActionResult> AddContactAsync(AddContactDTO contact, string accountName)
    {
      Account response = await accountService.AddContactAsync(contact, accountName);
      return (response == null) ? NotFound() : Ok(response);
    }

    [HttpPost("addAccount")]
    public async Task<ActionResult> AddAccountAsync(AddAccountDTO account, string incidentName)
    {
      Account response = await accountService.AddAccountAsync(account, incidentName);
      return (response == null) ? NotFound() : Ok(response);
    }

    [HttpPost("addIncident")]
    public async Task<ActionResult> AddIncidentAsync(AddIncidentDTO incident)
    {
      Incident response = await incidentService.AddIncidentAsync(incident);
      return (response == null) ? BadRequest() : Ok(response);
    }
  }
}
