using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities;
using Portfolio.Core.Interfaces;
using Portfolio.Infrastructure.Persistence;

namespace Portfolio.Infrastructure.Repositories;
public class ContactRepository(PortfolioContext portfolioContext) : IContactRepository
{
    public IQueryable<Contact> ReadOnlyContacts => portfolioContext.Set<Contact>().AsNoTracking();

    public async Task<Contact?> AddContactAsync(Contact contact)
    {
        portfolioContext.Contacts.Add(contact);
        int rowsAdded = await portfolioContext.SaveChangesAsync(0);
        return rowsAdded == 0 ? null : contact;
    }

    public async Task<List<Contact>> GetAllContactsAsync()
    {
        return await ReadOnlyContacts.ToListAsync();
    }

    public async Task<Contact?> GetContactByIdAsync(int contactId)
    {
        return await ReadOnlyContacts.FirstOrDefaultAsync(x => x.Id == contactId);
    }

    public async Task<Contact?> UpdateContactAsync(int contactId, Contact contact)
    {
        int rowsUpdated = await portfolioContext.Contacts.Where(x => x.Id == contactId)
                                        .ExecuteUpdateAsync(x => x.SetProperty(x => x.Name, contact.Name)
                                                                  .SetProperty(x=> x.Message, contact.Message)
                                                                  .SetProperty(x=> x.Phone, contact.Phone)
                                                                  .SetProperty(x=> x.Email, contact.Email));
        return rowsUpdated == 1 ? contact : null;
    }

    public async Task<bool> DeleteContactAsync(int contactId)
    {
        var rowsDeleted = await portfolioContext.Contacts.Where(x => x.Id == contactId).ExecuteDeleteAsync();
        return rowsDeleted == 1;
    }
}
