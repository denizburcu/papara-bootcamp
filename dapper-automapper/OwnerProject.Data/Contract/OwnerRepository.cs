using System.Data;
using Dapper;
using OwnerProject.Data.Context;
using OwnerProject.Domain.Models;

namespace OwnerProject.Data.Contract
{
    public class OwnerRepository : IRepository<Owner>
    {
        private readonly OwnerDapperContext _ownerDapperContext;

        public OwnerRepository(OwnerDapperContext ownerDapperContext)
        {
            _ownerDapperContext = ownerDapperContext;
        }

        public void Create(Owner entity)
        {
            var query = "INSERT INTO OWNER (NAME, SURNAME, DATE, DESCRIPTION, TYPE) "
            + "VALUES (@NAME, @SURNAME, @DATE, @DESCRIPTION, @TYPE)"
            + "SELECT CAST(SCOPE_IDENTITY() AS int)";

            var values = new DynamicParameters();
            values.Add("NAME", entity.Name, DbType.String);
            values.Add("SURNAME", entity.Surname, DbType.String);
            values.Add("DATE", System.DateTime.Now, DbType.DateTime);
            values.Add("DESCRIPTION", entity.Description, DbType.String);
            values.Add("TYPE", entity.Type, DbType.String);

            using (var connection = _ownerDapperContext.CreateConnection())
            {
                connection.Execute(query, values);
            }
        }

        public void Delete(int Id)
        {
            var query = "DELETE FROM OWNER WHERE ID = @ID";
            var values = new DynamicParameters();
            values.Add("ID", Id, DbType.Int32);

            using (var connection = _ownerDapperContext.CreateConnection())
            {
                connection.Execute(query, values);
            }
        }

        public IEnumerable<Owner> RetrieveAll()
        {
            var query = " SELECT ID, NAME, SURNAME, DATE, DESCRIPTION, TYPE FROM OWNER";
            using (var connection = _ownerDapperContext.CreateConnection())
            {
                var owner = connection.Query<Owner>(query);
                return owner.ToList();
            }
        }

        public Owner Retrive(int Id)
        {
            var query = "SELECT * FROM OWNER WHERE ID = @ID";

            var values = new DynamicParameters();
            values.Add("ID", Id, DbType.Int32);

            using (var connection = _ownerDapperContext.CreateConnection())
            {
                var owner = connection.QuerySingleOrDefault<Owner>(query, values);
                return owner;
            }
        }

        public Owner RetriveBySurname(String surname)
        {
            var query = "SELECT * FROM OWNER WHERE SURNAME = @SURNAME";

            var values = new DynamicParameters();
            values.Add("SURNAME", surname, DbType.String);

            using (var connection = _ownerDapperContext.CreateConnection())
            {
                var owner = connection.QuerySingleOrDefault<Owner>(query, values);
                return owner;
            }
        }

        public void Update(Owner entity)
        {
            var query = "UPDATE OWNER SET NAME = @NAME, SURNAME = @SURNAME, DESCRIPTION = @DESCRIPTION, TYPE = @TYPE WHERE ID = @ID";

            var values = new DynamicParameters();
            values.Add("ID", entity.Id, DbType.Int32);
            values.Add("NAME", entity.Name, DbType.String);
            values.Add("SURNAME", entity.Surname, DbType.String);
            values.Add("DESCRIPTION", entity.Description, DbType.String);
            values.Add("TYPE", entity.Type, DbType.String);

            using (var connection = _ownerDapperContext.CreateConnection())
            {
                connection.Execute(query, values);
            }
        }
    }
}