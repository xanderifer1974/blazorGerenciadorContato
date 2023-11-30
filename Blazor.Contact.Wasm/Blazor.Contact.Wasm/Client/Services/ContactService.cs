using Blazor.Contact.Wasm.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Blazor.Contact.Wasm.Client.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task DeleteContact(int id)
        {
            await _httpClient.DeleteAsync($"api/contact/{id}");
        }

        public async Task<IEnumerable<Contato>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Contato>>($"api/contact");
        }

        public async Task<Contato> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Contato>($"api/contact/{id}"); 
        }

        public async Task SaveContact(Contato contact)
        {
            if (contact.Id == 0)
                await _httpClient.PostAsJsonAsync<Contato>($"api/contact",contact);
            else
                await _httpClient.PutAsJsonAsync<Contato>($"api/contact/{contact.Id}", contact);
        }
    }
}
