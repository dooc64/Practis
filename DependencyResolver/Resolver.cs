using NoteBook.BLL;
using NoteBook.BLL.Interface;
using NoteBook.DAL;
using NoteBook.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyResolver
{
    public static class Resolver
    {
        private static INotesBL notesBL;
        private static INotesDAO notesDAO;
        static Resolver()
        {
            notesBL = new NotesBL(notesDAO);
            notesDAO = new NotesDAO();
        }

        static INotesBL NoteBL => notesBL;
        static INotesDAO NoteDAO => notesDAO;
    }
}
