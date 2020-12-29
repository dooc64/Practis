using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.DAL.Interface
{
    public interface INotesDAO
    {
        void Create(Note note);
        void DeleteByID(int id);
        void Update(Note note);
        Note GetByID(int id);
        IEnumerable<Note> GetAll();
        IEnumerable<Note> SearchByName(string name);
    }
}
