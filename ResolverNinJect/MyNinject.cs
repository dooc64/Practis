using Ninject.Modules;
using NoteBook.BLL;
using NoteBook.BLL.Interface;
using NoteBook.DAL;
using NoteBook.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteBook.Common.ResolverNinJect
{
    public class MyNinject : NinjectModule
    {
        public override void Load()
        {
            Bind<INotesDAO>().To<NotesDAO>();
            Bind<INotesBL>().To<NotesBL>();
            Bind<IUserBL>().To<UserBL>();
            Bind<IUserDAO>().To<UserDAO>();
        }
    }
}