using System.Data;

namespace Blazor.Contacts.Wasm.Repositories
{
    public class ContactRepository: IContactRepository
    {
        private readonly IDbConnection _dbConnection;

        public ContactRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
    }
}
