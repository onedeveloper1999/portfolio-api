using Portfolio.Application.DataContracts;
using Portfolio.Application.Interfaces;
using Portfolio.Core.Constants;
using Portfolio.Core.Entities;
using Portfolio.Core.Interfaces;
using System.Net;

namespace Portfolio.Application.Services;
public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<ApiResponse> AddUserAsync(UserDto UserDto)
    {
        var user = new User
        {
            Username = UserDto.Username,
            PasswordHash = UserDto.PasswordHash,
            Role = UserDto.Role
        };
        var result = await userRepository.AddUserAsync(user);
        return new ApiResponse(ApiResponseMessage.Success, result, HttpStatusCode.OK);
    }

    public async Task<ApiResponse> GetAllUsersAsync()
    {
        var result = await userRepository.GetAllUsersAsync();
        return new ApiResponse(ApiResponseMessage.Success, result, HttpStatusCode.OK);
    }

    public async Task<ApiResponse> GetUserByIdAsync(int UserId)
    {
        var result = await userRepository.GetUserByIdAsync(UserId);
        return new ApiResponse(ApiResponseMessage.Success, result, HttpStatusCode.OK);
    }

    public async Task<ApiResponse> UpdateUserAsync(int UserId, UserDto UserDto)
    {
        var user = new User
        {
            Username = UserDto.Username,
            PasswordHash = UserDto.PasswordHash,
            Role = UserDto.Role
        };
        var result = await userRepository.UpdateUserAsync(UserId,user);
        return new ApiResponse(ApiResponseMessage.Success, result, HttpStatusCode.OK);
    }

    public async Task<ApiResponse> DeleteUserAsync(int UserId)
    {
        var result = await userRepository.DeleteUserAsync(UserId);
        return new ApiResponse(ApiResponseMessage.Success, result, HttpStatusCode.OK);
    }
}
