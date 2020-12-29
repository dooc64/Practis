using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.DAL.Interface
{
    public interface IUserDAO
    {
        int Create(string login, string password);
        int Login(string login, string password);
        string[] UserInRoles(string login);
    }
}
