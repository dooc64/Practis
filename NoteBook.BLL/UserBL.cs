using NoteBook.BLL.Interface;
using NoteBook.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.BLL
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAO userDAO;

        public UserBL(IUserDAO userDAO)
        {
            this.userDAO = userDAO;
        }
        public int Create(string login, string password)
        {
            return userDAO.Create(login, password);
        }

        public int LogIn(string login, string password)
        {
            return userDAO.Login(login, password);
        }

        public string[] UserInRoles(string login)
        {
            return userDAO.UserInRoles(login);
        }
    }
}
