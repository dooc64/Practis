using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.BLL.Interface
{
    public interface INotesBL
    {
        void Create(Note note);
        void DeleteByID(int id);
        void Update(Note note);
        Note GetByID(int id);
        IEnumerable<Note> GetAll();
        IEnumerable<Note> SearchByName(string name);
    }
}
