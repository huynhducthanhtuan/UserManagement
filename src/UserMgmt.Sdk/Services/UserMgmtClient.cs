using System.Net.Http.Json;
using UserMgmt.Sdk.Models;

namespace UserMgmt.Sdk.Services;

public class UserMgmtClient : IUserMgmtClient
{
    private readonly HttpClient _httpClient;

    public UserMgmtClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<UserDto>>("api/users");
    }

    public async Task<UserDto?> GetUserAsync(string name)
    {
        return await _httpClient.GetFromJsonAsync<UserDto>($"api/users/{name}");
    }
}
