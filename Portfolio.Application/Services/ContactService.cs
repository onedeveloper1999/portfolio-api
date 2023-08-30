using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Portfolio.Application.DataContracts;
using Portfolio.Application.Interfaces;
using Portfolio.Core.Constants;
using Portfolio.Core.Entities;
using Portfolio.Core.Interfaces;

namespace Portfolio.Application.Services;
public class ContactService(IContactRepository contactRepository) : IContactService
{
    public async Task<ApiResponse> AddContactAsync(ContactDto contactDto)
    {
        var contact = new Contact
        {
            Name = contactDto.Name,
            Email = contactDto.Email,
            Message = contactDto.Message,
            Phone = contactDto.Phone
        };
        var result = await contactRepository.AddContactAsync(contact);
        return new ApiResponse(ApiResponseMessage.Success,result,StatusCodes.Status200OK);
    }

    public async Task<ApiResponse> DeleteContactAsync(int contactId)
    {
        var result = await contactRepository.DeleteContactAsync(contactId);
        return new ApiResponse(ApiResponseMessage.Success, result, StatusCodes.Status200OK);
    }

    public async Task<ApiResponse> GetAllContactsAsync()
    {
        var result = await contactRepository.GetAllContactsAsync();
        return new ApiResponse(ApiResponseMessage.Success, result, StatusCodes.Status200OK);
    }

    public async Task<ApiResponse> GetContactByIdAsync(int contactId)
    {
        var result = await contactRepository.GetContactByIdAsync(contactId);
        return new ApiResponse(ApiResponseMessage.Success, result, StatusCodes.Status200OK);
    }

    public async Task<ApiResponse> UpdateContactAsync(int contactId, ContactDto contactDto)
    {
        var contact = new Contact
        {
            Name = contactDto.Name,
            Email = contactDto.Email,
            Message = contactDto.Message,
            Phone = contactDto.Phone
        };
        var result = await contactRepository.UpdateContactAsync(contactId,contact);
        return new ApiResponse(ApiResponseMessage.Success, result, StatusCodes.Status200OK);
    }
}
