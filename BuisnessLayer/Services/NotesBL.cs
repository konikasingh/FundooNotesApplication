using BuisnessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services
{
    public class NotesBL : INotesBL
    {
        INotesRL NotesRL;
        public NotesBL(INotesRL userRL)
        {
            this.NotesRL = userRL;
        }
        public bool CreateNotes(NotesModel client, long tokenId)
        {
            try
            {
                return this.NotesRL.CreateNotes(client, tokenId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Notes> GetNotesDetail()
        {
            return this.NotesRL.GetNotesDetail();
        }

        public Notes GetWithId(long id)
        {
            try
            {
                return this.NotesRL.GetWithId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateNotes(Notes APerson, Notes person)
{
            try
            {
                this.NotesRL.UpdateNotes(APerson,person);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteNotes(Notes person)
        {
            try
            {
                this.NotesRL.DeleteNotes(person);
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public string PinorUnpinNote(int id)
        {
            try
            {
                var note = this.NotesRL.PinorUnpinNote(id);
                return note;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
        public string ArchiveOrUnArchieveNote(int id)
        {
            try
            {
                var note = this.NotesRL.ArchiveOrUnArchieveNote(id);
                return note;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public string TrashOrRestoreNote(int id)
        {
            try
            {
                var note = this.NotesRL.TrashOrRestoreNote(id);
                return note;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string AddColor(long id, string color)
        {
            try
            {
                string message = this.NotesRL.AddColor(id, color);
                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
