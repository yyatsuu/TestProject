using TestProject.Models;
using TestProject.Models.DTO;

namespace TestProject.Services.Interfaces
{
  public interface IAccountService
  {
    public Task<Account> AddContactAsync(AddContactDTO contact, string accountName);
    public Task<Account> AddAccountAsync(AddAccountDTO account, string incidentName);
  }
}
