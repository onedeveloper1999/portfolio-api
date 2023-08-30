using AutoWrapper.Wrappers;
using Portfolio.Application.DataContracts;

namespace Portfolio.Application.Interfaces;
public interface IContactMessageService
{
    Task<ApiResponse> AddContactMessageAsync(ContactMessageDto contactMessageDto);
    Task<ApiResponse> DeleteContactMessageAsync(int contactMessageId);
    Task<ApiResponse> GetAllContactMessageAsync();
    Task<ApiResponse> GetContactMessageByIdAsync(int contactMessageId);
    Task<ApiResponse> UpdateContactMessageAsync(int contactMessageId,ContactMessageDto contactMessageDto);
}
