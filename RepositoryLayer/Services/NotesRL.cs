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
    }
}
