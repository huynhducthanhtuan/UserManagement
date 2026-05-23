using UserMgmt.Sdk.Models;

namespace UserMgmt.Sdk.Services;

public interface IUserMgmtClient
{
    Task<IEnumerable<UserDto>> GetUsersAsync();
    Task<UserDto?> GetUserAsync(string name);
}
