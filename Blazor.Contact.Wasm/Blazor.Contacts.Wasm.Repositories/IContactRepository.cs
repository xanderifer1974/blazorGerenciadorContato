using Blazor.Contacts.Wasm.Repositories.Models;
using System.Threading.Tasks;

namespace Blazor.Contacts.Wasm.Repositories
{
    public  interface IContactRepository
    {
        Task<bool> InsertContact(Contact contato);
    }
}
