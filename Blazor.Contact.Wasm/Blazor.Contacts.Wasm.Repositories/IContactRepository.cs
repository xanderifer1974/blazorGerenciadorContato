using Blazor.Contacts.Wasm.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.Contacts.Wasm.Repositories
{
    public  interface IContactRepository
    {
        Task<bool> InsertContact(Contact contato);

        Task<bool> UpdateContact(Contact contato);

        Task DeleteContact(int id);

        Task<IEnumerable<Contact>> GetAllContacts();

        Task<Contact> GetContactById(int id);
    }
}
