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
        public bool CreateNotes(NotesModel client)
        {
            try
            {
                return this.NotesRL.CreateNotes(client);
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
        /// <summary>
        /// Method to call GetPinnedNote method from NotesRepository 
        /// </summary>
        /// <returns>pinned note</returns>
        public IEnumerable<Notes> GetPinnedNote()
        {
            try
            {
                IEnumerable<Notes> note = this.NotesRL.GetPinnedNote();
                return note;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string PinOrUnpinNote(int id)
        {
            try
            {
                var note = this.NotesRL.PinOrUnpinNote(id);
                return note;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
