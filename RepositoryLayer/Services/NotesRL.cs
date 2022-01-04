using CommonLayer.Models;
using RepositoryLayer.Context;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class NotesRL : INotesRL //interface of notes class
    {
        ucontext context;

        public NotesRL(ucontext context)
        {
            this.context = context;  //created the context parameter of context class
        }
        /// <summary>
        /// It will create the note for the particular user
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool CreateNotes(NotesModel client)
        {
            try
            {
                Notes newNote = new Notes();
                newNote.Id = client.Id;
                newNote.Title = client.Title;
                newNote.Message = client.Message;
                newNote.Remainder = client.Remainder;
                newNote.Color = client.Color;
                newNote.Image = client.Image;
                newNote.IsArchive = client.IsArchive;
                newNote.IsPin = client.IsPin;
                this.context.NotesTable.Add(newNote);

                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get all details of notes which is in database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Notes> GetNotesDetail()
        {
            return context.NotesTable.ToList();
        }
        /// <summary>
        /// Get the notes details with using id parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Notes GetWithId(long id)
        {
            try
            {
                return this.context.NotesTable.FirstOrDefault(i => i.NotesId == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update the notes using the id parameter
        /// </summary>
        /// <param name="APerson"></param>
        /// <param name="person"></param>
        public void UpdateNotes(Notes APerson, Notes person)
        {
            try
            {
                APerson.Title = person.Title;
                APerson.Message = person.Message;
                APerson.Color = person.Color;
                APerson.Image = person.Image;
                APerson.IsArchive = person.IsArchive;
                APerson.IsPin = person.IsPin;
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete the particular notes using id
        /// </summary>
        /// <param name="person"></param>       
        public void DeleteNotes(Notes person)
        {
            try
            {
                this.context.NotesTable.Remove(person);
                this.context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }
        ///// <summary>
        ///// Method implementation to get pinned note
        ///// </summary>
        ///// <returns>pinned note</returns>
        //public IEnumerable<Notes> GetPinnedNote()
        //{
        //    try
        //    {
        //        IEnumerable<Notes> result;
        //        var note = this.context.NotesTable.Where(x => x.IsPin == true);
        //        result = note;
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        /// <summary>
        /// Method to Pin Or Unpin the Note 
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string PinNote(int id)
        {
            try
            {
                string message;
                var newNote = new Notes() { NotesId = id };
                var note = this.context.NotesTable.FirstOrDefault(x => x.NotesId == id).IsPin;
                if (note == false)
                {
                    
                    var pinNote = this.context.NotesTable.FirstOrDefault(x => x.NotesId == id).IsPin == true;
                    var pinThisNote = context.NotesTable.FirstOrDefault(u => u.NotesId == id);
                    pinThisNote.IsPin = pinNote;
                    this.context.SaveChanges();

                    message = "Note Pinned";
                    return message;

                }
                return message = "Note is unpinned by default.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UnpinNote(int id)
        {
            try
            {
                string message;
                var newNote = new Notes() { NotesId = id };
                var note = this.context.NotesTable.FirstOrDefault(x => x.NotesId == id).IsPin;
                if (note == true)
                {                   
                    var unpinNote = this.context.NotesTable.FirstOrDefault(x => x.NotesId == id).IsPin == false;
                    var unpinThisNote = context.NotesTable.FirstOrDefault(u => u.NotesId == id);
                    unpinThisNote.IsPin = unpinNote;
                    this.context.SaveChanges();
                    message = "Note Unpinned";
                    return message;
                }
                return message = "Note is unpinned by default.";
            }


            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    
        /// <summary>
        /// Method to Archive or unarchive the note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string ArchiveNote(int id)
        {
            try
            {
                string message;
                var note = this.context.NotesTable.FirstOrDefault(x => x.NotesId == id).IsArchive;
                if (note == false)
                {
                    var archiveNote = this.context.NotesTable.FirstOrDefault(x => x.NotesId == id).IsArchive == true;
                    var archiveThisNote = context.NotesTable.FirstOrDefault(u => u.NotesId == id);
                    archiveThisNote.IsArchive = archiveNote;
                    this.context.SaveChanges();
                    message = "Note Archived";
                    return message;
                }
                
                return message = "Unable to archive or unarchive note.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
