using Entities;
using NoteBook.BLL.Interface;
using NoteBook.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.BLL
{
    public class NotesBL : INotesBL
    { 
        private INotesDAO _notesDAO { get; }
        public NotesBL(INotesDAO notesDAO)
        {
            _notesDAO = notesDAO;
        }

        public void Create(Note note)
        {
            _notesDAO.Create(note);
        }

        public void DeleteByID(int id)
        {
            _notesDAO.DeleteByID(id);
        }

        public IEnumerable<Note> GetAll()
        {
            return _notesDAO.GetAll();
        }

        public Note GetByID(int id)
        {
            return _notesDAO.GetByID(id);
        }

        public void Update(Note note)
        {
            _notesDAO.Update(note);
        }

        public IEnumerable<Note> SearchByName(string name)
        {
            return _notesDAO.SearchByName(name);
        }
    }
}
