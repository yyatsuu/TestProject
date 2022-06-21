using TestProject.Models;
using TestProject.Models.DTO;

namespace TestProject.Services.Interfaces
{
  public interface IContactService
  {
    public Task<Contact> AddContactAsync(AddContactDTO contact, int accountId);
    public Task<Contact> UpdateContactAsync(UpdateContactDTO contact, int accountId);
  }
}
