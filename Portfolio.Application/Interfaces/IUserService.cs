using AutoWrapper.Wrappers;
using Portfolio.Application.DataContracts;

namespace Portfolio.Application.Interfaces;
public interface IUserService
{
    Task<ApiResponse> AddUserAsync(UserDto UserDto);
    Task<ApiResponse> GetAllUsersAsync();
    Task<ApiResponse> GetUserByIdAsync(int UserId);
    Task<ApiResponse> UpdateUserAsync(int UserId, UserDto UserDto);
    Task<ApiResponse> DeleteUserAsync(int UserId);
}
