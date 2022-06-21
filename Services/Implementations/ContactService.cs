using Microsoft.EntityFrameworkCore;
using TestProject.Models;
using TestProject.Models.DTO;
using TestProject.Services.Interfaces;

namespace TestProject.Services.Implementations
{
  public class ContactService : IContactService
  {
    private readonly Context context;

    public ContactService(Context context)
    {
      this.context = context;
    }

    public async Task<Contact> AddContactAsync(AddContactDTO contact, int accountId)
    {
      Contact addedContact = new()
      {
        FirstName = contact.FirstName,
        LastName = contact.LastName,
        Email = contact.Email,
        AccountId = accountId
      };

      await context.Contacts.AddAsync(addedContact);
      await context.SaveChangesAsync();

      return addedContact;
    }

    public async Task<Contact> UpdateContactAsync(UpdateContactDTO contact, int accountId)
    {
      Contact? updatedContact = await context.Contacts.FirstOrDefaultAsync(con => con.Id == contact.Id);

      if(updatedContact == null) { return null; }

      updatedContact.FirstName = contact.FirstName;
      updatedContact.LastName = contact.LastName;
      updatedContact.Email = contact.Email;
      updatedContact.AccountId = accountId;

      context.Entry(updatedContact).State = EntityState.Modified;
      await context.SaveChangesAsync();

      return updatedContact;
    }
  }
}
