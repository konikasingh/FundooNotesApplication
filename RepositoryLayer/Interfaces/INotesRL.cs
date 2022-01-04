using CommonLayer.Models;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface INotesRL
    {
        public bool CreateNotes(NotesModel client);
        public IEnumerable<Notes> GetNotesDetail();
        public Notes GetWithId(long id);
        public void UpdateNotes(Notes APerson, Notes person);
        public void DeleteNotes(Notes person);
        //public IEnumerable<Notes> GetPinnedNote();
        public string PinNote(int id);
        public string UnpinNote(int id);
        public string ArchiveNote(int id);
    }
}
