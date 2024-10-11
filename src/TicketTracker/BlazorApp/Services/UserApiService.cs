using Domain.Models;

namespace BlazorApp.Services
{
    public class UserApiService
    {
        private HttpClient client;

        public UserApiService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await client.GetFromJsonAsync<IEnumerable<User>>("api/users");
        }
    }


}