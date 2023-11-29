using Blazor.Contact.Wasm.Shared;
using System.Collections.Generic;
using System.Net.Http;
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


        public Task DeleteContact(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Contato>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Contato> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveContact(Contato contact)
        {
            throw new System.NotImplementedException();
        }
    }
}
