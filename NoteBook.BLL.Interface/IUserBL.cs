using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.BLL.Interface
{
    public interface IUserBL
    {
        int Create(string login, string password);
        int LogIn(string login, string password);
        string[] UserInRoles(string login);
    }
}
