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
    public class NotesRL : INotesRL
    {
        ucontext context;

        public NotesRL(ucontext context)
        {
            this.context = context;
        }

        public bool CreateNotes(NotesModel client)
        {
            try
            {
                Notes newNote = new Notes();
                newNote.Id = client.Id;
                newNote.NotesId = client.NotesId;
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
        
        public IEnumerable<Notes> GetNotesDetail()
        {
            return context.NotesTable.ToList();
        }
       
        public Notes GetWithId(long id)
        {
            try
            {
                return this.context.NotesTable.FirstOrDefault(i => i.Id == id);
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
