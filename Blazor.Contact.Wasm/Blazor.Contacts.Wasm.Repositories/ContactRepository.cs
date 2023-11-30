using Blazor.Contact.Wasm.Shared;
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

        public async  Task DeleteContact(int id)
        {
            var sql = @"DELETE FROM Contacts
                        WHERE Id = @Id ";

            var result = await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Contato>> GetAllContacts()
        {
            var sql = @" SELECT Id
                                ,FirstName
                                ,LastName
                                ,Phone
                                ,Address
                           FROM  Contacts";


            return await _dbConnection.QueryAsync<Contato>(sql,
                new { });
        }

        public async Task<Contato> GetContactById(int id)
        {
            var sql = @" SELECT Id
                                ,FirstName
                                ,LastName
                                ,Phone
                                ,Address
                           FROM  Contacts
                           WHERE Id = @Id";


            return await _dbConnection.QueryFirstOrDefaultAsync<Contato>(sql,
                new {Id = id});

        }

        public async Task<bool> InsertContact(Contato contato)
        {
            try
            {
                var sql = @"INSERT INTO Contacts(FirstName,LastName,Phone,Address)
                          VALUES (@FirstName,@LastName,@Phone,@Address)";

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

        public async Task<bool> UpdateContact(Contato contato)
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
