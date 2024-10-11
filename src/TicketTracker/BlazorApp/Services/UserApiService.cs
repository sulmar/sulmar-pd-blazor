using Domain.Models;

namespace BlazorApp.Services;

public class UserApiService(HttpClient client)
{
    public async Task<IEnumerable<User>> GetAllAsync() 
        => await client.GetFromJsonAsync<IEnumerable<User>>("api/users");
}


