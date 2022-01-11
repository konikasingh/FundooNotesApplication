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
        public bool CreateNotes(NotesModel client, long tokenId);
        public IEnumerable<Notes> GetNotesDetail();
        public Notes GetWithId(long id);
        public void UpdateNotes(Notes APerson, Notes person);
        public void DeleteNotes(Notes person);
        public string PinorUnpinNote(int id);
        public string ArchiveOrUnArchieveNote(int id);
        public string TrashOrRestoreNote(int id);
        public string AddColor(long id, string color);
        
    }
}
