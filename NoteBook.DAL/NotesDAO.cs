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
    public class NotesDAO : INotesDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Notes; User ID = Admin; password = Admin;Integrated Security = False; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void Create(Note note)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.Create";

                var nameParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@name",
                    Value = note.Name,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(nameParam);


                var textParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@text",
                    Value = note.Text,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(textParam);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void DeleteByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.Delete";

                var idParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@id",
                    Value = id,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(idParam);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Note> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetALL";

                connection.Open();

                var notes = new List<Note>();
                var result = command.ExecuteReader();

                while(result.Read())
                {
                    notes.Add(new Note
                    {
                        ID = (int)result["id"],
                        Name = result["name"] as string,
                        Text = result["text"] as string
                    });
                };
                return notes;
            }
        }

        public Note GetByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.GetByID";

                var idParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@id",
                    Value = id,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(idParam);

                connection.Open();

                var result = command.ExecuteReader();

                if (!result.Read())
                    return null;

                return new Note
                {
                    ID = id,
                    Name = result["name"] as string,
                    Text = result["text"] as string
                };
            }
        }

        public IEnumerable<Note> SearchByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.SearchByName";
                var nameParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@name",
                    Value = name,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(nameParam);

                connection.Open();

                var notes = new List<Note>();
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    notes.Add(new Note
                    {
                        ID = (int)result["id"],
                        Name = result["name"] as string,
                        Text = result["text"] as string
                    });
                };
                return notes;
            }

        }

        public void Update(Note note)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.Update";

                var nameParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@name",
                    Value = note.Name,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(nameParam);


                var textParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@text",
                    Value = note.Text,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(textParam);


                var idParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@id",
                    Value = note.ID,
                    Direction = System.Data.ParameterDirection.Input
                };
                command.Parameters.Add(idParam);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
