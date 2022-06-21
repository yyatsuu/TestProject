using Microsoft.EntityFrameworkCore;
using TestProject.Models;
using TestProject.Models.DTO;
using TestProject.Services.Interfaces;

namespace TestProject.Services.Implementations
{
  public class AccountService : IAccountService
  {
    private readonly IContactService contactService;
    private readonly Context context;

    public AccountService(IContactService contactService, Context context)
    {
      this.contactService = contactService;
      this.context = context;
    }

    public async Task<Account> AddContactAsync(AddContactDTO contact, string accountName)
    {
      Account? account = await context.Accounts.FirstOrDefaultAsync(acc => acc.Name == accountName);

      if (account == null) { return null; }

      var addedContact = await context.Contacts.FirstOrDefaultAsync(con => con.Email == contact.Email);

      if (addedContact != null) { return null; }

      addedContact = await contactService.AddContactAsync(contact, account.Id);

      account.Contacts.Add(addedContact);

      await context.SaveChangesAsync();

      return account;
    }

    public async Task<Account> AddAccountAsync(AddAccountDTO account, string incidentName)
    {
      Contact? contact = await context.Contacts.FirstOrDefaultAsync(con => con.Email == account.Email);
      Account? addedAccount = await context.Accounts.FirstOrDefaultAsync(acc => acc.Name == account.Name);

      if (addedAccount != null) { return null; }

      addedAccount = new()
      {
        Name = account.Name,
        IncidentName = incidentName
      };

      await context.Accounts.AddAsync(addedAccount);
      await context.SaveChangesAsync();

      if(contact is null)
      {
        var temp = new AddContactDTO
        {
          FirstName = account.FirstName,
          LastName = account.LastName,
          Email = account.Email,
        };

        contact = await contactService.AddContactAsync(temp, addedAccount.Id);
      }
      else
      {
        var temp = new UpdateContactDTO
        {
          Id = contact.Id,
          FirstName = contact.FirstName,
          LastName = contact.LastName,
          Email = contact.Email,
        };
        contact = await contactService.UpdateContactAsync(temp, addedAccount.Id);
      }

      addedAccount.Contacts.Add(contact);

      return addedAccount;
    }
  }
}
