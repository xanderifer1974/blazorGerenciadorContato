using Blazor.Contact.Wasm.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.Contact.Wasm.Client.Services
{
    public interface IContactService
    {
        Task SaveContact(Contato contact);
        Task DeleteContact(int id);
        Task<IEnumerable<Contato>> GetAll();
        Task<Contato> GetById(int id);
    }
}
