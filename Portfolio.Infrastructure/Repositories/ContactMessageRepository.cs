using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities;
using Portfolio.Core.Interfaces;
using Portfolio.Infrastructure.Persistence;

namespace Portfolio.Infrastructure.Repositories;
public class ContactMessageRepository(PortfolioContext portfolioContext) : IContactMessageRepository
{
    public async Task<ContactMessage?> AddContactMessageAsync(ContactMessage contactMessage)
    {
        portfolioContext.ContactMessages.Add(contactMessage);
        int rowsAdded = await portfolioContext.SaveChangesAsync();
        return rowsAdded == 0 ? null : contactMessage;
    }

    public async Task<List<ContactMessage>> GetAllContactMessagesAsync()
    {
        return await portfolioContext.ContactMessages.ToListAsync();
    }

    public async Task<ContactMessage?> GetContactMessageByIdAsync(int contactMessageId)
    {
        return await portfolioContext.ContactMessages.FirstOrDefaultAsync(x => x.Id == contactMessageId);
    }

    public async Task<ContactMessage?> UpdateContactMessageAsync(int contactMessageId, ContactMessage contactMessage)
    {
        int rowsUpdated = await portfolioContext.ContactMessages.Where(x => x.Id == contactMessageId).ExecuteUpdateAsync(x => x.SetProperty(x => x, contactMessage));
        return rowsUpdated == 1 ? contactMessage : null;
    }

    public async Task<bool> DeleteContactMessageAsync(int contactMessageId)
    {
        var rowsDeleted = await portfolioContext.ContactMessages.Where(x => x.Id == contactMessageId).ExecuteDeleteAsync();
        return rowsDeleted == 1;
    }
}