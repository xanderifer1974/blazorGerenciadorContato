using Blazor.Contacts.Wasm.Repositories.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Blazor.Contacts.Wasm.Repositories
{
    public class ContactRepository : IContactRepository
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

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            var sql = @" SELECT Id
                                ,FirstName
                                ,LastName
                                ,Phone
                                ,Address
                           FROM  Contacts
                           WHERE Id = @Id";


            return await _dbConnection.QueryAsync<Contact>(sql,
                new { });
        }

        public async Task<Contact> GetContactById(int id)
        {
            var sql = @" SELECT Id
                                ,FirstName
                                ,LastName
                                ,Phone
                                ,Address
                           FROM  Contacts
                           WHERE Id = @Id";


            return await _dbConnection.QueryFirstOrDefaultAsync<Contact>(sql,
                new {Id = id});

        }

        public async Task<bool> InsertContact(Contact contato)
        {
            try
            {
                var sql = @"INSERT INTO Contacts(FirstName,LastName,Phone,Address)
                          VALUE(@FirstName,@LastName,@Phone,@Address)";

                var result = await _dbConnection.ExecuteAsync(
                    sql, new
                    {
                        contato.FirstName,
                        contato.LastName,
                        contato.Phone,
                        contato.Address
                    });

                return result > 0;


            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateContact(Contact contato)
        {
            try
            {
                var sql = @"UPDATE Contacts SET 
                            FirstName = @FirstName,
                            LastName = @LastName,
                            Phone = @Phone,
                            Address = @Address )
                            WHERE Id = @Id";


                var result = await _dbConnection.ExecuteAsync(
                    sql, new
                    {
                        contato.FirstName,
                        contato.LastName,
                        contato.Phone,
                        contato.Address,
                        contato.Id
                    });

                return result > 0;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
