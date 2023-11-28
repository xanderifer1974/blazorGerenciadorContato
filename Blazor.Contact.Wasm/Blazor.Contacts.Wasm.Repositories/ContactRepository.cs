using Blazor.Contacts.Wasm.Repositories.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Blazor.Contacts.Wasm.Repositories
{
    public class ContactRepository: IContactRepository
    {
        private readonly IDbConnection _dbConnection;

        public ContactRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task DeleteContact(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Contact>> GetAllContacts()
        {
            throw new System.NotImplementedException();
        }

        public Task<Contact> GetContactById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertContact(Contact contato)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateContact(Contact contato)
        {
            throw new System.NotImplementedException();
        }
    }
}
