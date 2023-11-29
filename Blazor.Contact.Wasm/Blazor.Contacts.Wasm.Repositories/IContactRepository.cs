using Blazor.Contact.Wasm.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.Contacts.Wasm.Repositories
{
    public  interface IContactRepository
    {
        Task<bool> InsertContact(Contato contato);

        Task<bool> UpdateContact(Contato contato);

        Task DeleteContact(int id);

        Task<IEnumerable<Contato>> GetAllContacts();

        Task<Contato> GetContactById(int id);
    }
}
