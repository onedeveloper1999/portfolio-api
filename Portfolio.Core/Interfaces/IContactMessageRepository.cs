using Portfolio.Core.Entities;

namespace Portfolio.Core.Interfaces;
public interface IContactMessageRepository
{
    Task<List<ContactMessage>> GetAllContactMessagesAsync();
    Task<ContactMessage?> GetContactMessageByIdAsync(int contactMessageId);
    Task<ContactMessage?> AddContactMessageAsync(ContactMessage contactMessage);
    Task<ContactMessage?> UpdateContactMessageAsync(int contactMessageId, ContactMessage contactMessage);
    Task<bool> DeleteContactMessageAsync(int contactMessageId);
}