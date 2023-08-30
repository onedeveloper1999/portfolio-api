using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Portfolio.Application.DataContracts;
using Portfolio.Application.Interfaces;
using Portfolio.Core.Constants;
using Portfolio.Core.Entities;
using Portfolio.Core.Interfaces;

namespace Portfolio.Application.Services;
internal class ContactMessgeService(IContactMessageRepository contactMessageRepository) : IContactMessageService
{
    public async Task<ApiResponse> AddContactMessageAsync(ContactMessageDto contactMessageDto)
    {
        var contactMessage = new ContactMessage
        {
            UserId = contactMessageDto.UserId,
            Message = contactMessageDto.Message,
            Timestamp = DateTime.UtcNow
        };
        var result = await contactMessageRepository.AddContactMessageAsync(contactMessage);
        return new ApiResponse(ApiResponseMessage.Success, result, StatusCodes.Status200OK);
    }

    public async Task<ApiResponse> GetAllContactMessageAsync()
    {
        var result = await contactMessageRepository.GetAllContactMessagesAsync();
        return new ApiResponse(ApiResponseMessage.Success, result, StatusCodes.Status200OK);
    }

    public async Task<ApiResponse> GetContactMessageByIdAsync(int contactMessageId)
    {
        var result = await contactMessageRepository.GetContactMessageByIdAsync(contactMessageId);
        return new ApiResponse(message: ApiResponseMessage.Success, result: result, statusCode: StatusCodes.Status200OK);
    }

    public async Task<ApiResponse> UpdateContactMessageAsync(int contactMessageId,ContactMessageDto contactMessageDto)
    {
        var contactMessage = new ContactMessage
        {
            UserId = contactMessageDto.UserId,
            Message = contactMessageDto.Message,
            Timestamp = DateTime.UtcNow
        };
        var result = await contactMessageRepository.UpdateContactMessageAsync(contactMessageId,contactMessage);
        return new ApiResponse(ApiResponseMessage.Success, result, StatusCodes.Status200OK);
    }

    public async Task<ApiResponse> DeleteContactMessageAsync(int contactMessageId)
    {
        var result = await contactMessageRepository.DeleteContactMessageAsync(contactMessageId);
        return new ApiResponse(ApiResponseMessage.Success, result, StatusCodes.Status200OK);
    }
}
