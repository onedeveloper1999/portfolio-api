using Portfolio.Application.DataContracts;

namespace Portfolio.Application.Interfaces;
public interface IContactService
{
    Task<ApiResponse> AddContactAsync(ContactDto contactDto);
    Task<ApiResponse> GetAllContactsAsync();
    Task<ApiResponse> GetContactByIdAsync(int contactId);
    Task<ApiResponse> UpdateContactAsync(int contactId, ContactDto contactDto);
    Task<ApiResponse> DeleteContactAsync(int contactId);
}
