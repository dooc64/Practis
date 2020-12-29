using Entities;
using NoteBook.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.DAL
{
    public class UserDAO : IUserDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Notes; User ID = Admin; password = Admin;Integrated Security = False; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int Create(string login, string password)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.UserCreate";

                var loginParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@login",
                    Value = login,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(loginParam);


                var passwordParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@password",
                    Value = password,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(passwordParam);

                var idParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@id",
                    Value = id,

                    Direction = System.Data.ParameterDirection.Output
                };
                command.Parameters.Add(idParam);

                connection.Open();
                
                var result = command.ExecuteReader();

                if (!result.Read())
                    return 0;

                return (int)result["id"];
            };
        }
        public int Login(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.UserLogin";

                var loginParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@login",
                    Value = login,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(loginParam);


                var passwordParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@password",
                    Value = password,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(passwordParam);

                connection.Open();

                var result = command.ExecuteReader();

                if (!result.Read())
                    return 0;

                return (int)result["id"];
            };
        }

        public string[] UserInRoles(string login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetRoleFromUser";

                var loginParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@login",
                    Value = login,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(loginParam);

                var roles = new List<string>();
                connection.Open();

                var result = command.ExecuteReader();

                while (!result.Read())
                {
                    roles.Add(result["UserRole"] as string);
                }
                return roles.ToArray();
            };
        }
    }
}
