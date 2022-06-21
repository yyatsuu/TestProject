using TestProject.Models;
using TestProject.Models.DTO;

namespace TestProject.Services.Interfaces
{
  public interface IIncidentService
  {
    public Task<Incident> AddIncidentAsync(AddIncidentDTO incident);
  }
}
