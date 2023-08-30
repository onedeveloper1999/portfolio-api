using Portfolio.Core.Entities;

namespace Portfolio.Core.Interfaces;
public interface IContactRepository
{
    IQueryable<Contact> ReadOnlyContacts { get; }
    Task<List<Contact>> GetAllContactsAsync();
    Task<Contact?> GetContactByIdAsync(int contactId);
    Task<Contact?> AddContactAsync(Contact contact);
    Task<Contact?> UpdateContactAsync(int contactId, Contact contact);
    Task<bool> DeleteContactAsync(int contactId);
}