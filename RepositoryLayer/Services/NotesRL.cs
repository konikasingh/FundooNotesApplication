using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;
        public NotesRL(ucontext context, IConfiguration config)
        {
            this.context = context;  //created the context parameter of context class
            _config = config;
        }
        /// <summary>
        /// It will create the note for the particular user
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool CreateNotes(NotesModel client, long tokenId)
        {
            try
            {
                Notes newNote = new Notes();
                newNote.Id = tokenId;
                newNote.Title = client.Title;
                newNote.Message = client.Message;
                newNote.Color = client.Color;
                newNote.Image = client.Image;
                newNote.IsArchive = client.IsArchive;
                newNote.IsPin = client.IsPin;
                newNote.IsTrash = client.IsTrash;
                newNote.Createat = client.Createat;
                newNote.Modifiedat = client.Modifiedat;
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
                //var user = this.context.NotesTable.FirstOrDefault(e => e.NotesId == id && e.Id == TokenId && e.IsPin == true);
                //if (user != null)
                //{
                //    NotesModel model = new()
                //    {
                //        Id = user.Id,
                //        NotesId = user.NotesId,
                //        Title = user.Title,
                //        Message = user.Message,
                //        Color = user.Color,
                //        Image = user.Image,
                //        IsPin = user.IsPin,
                //        IsArchive = user.IsArchive,
                //        IsTrash = user.IsTrash,
                //        Createat = user.Createat,
                //        Modifiedat = user.Modifiedat
                //    };
                //    return model;
                //}
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
        /// <summary>
        /// Method to Pin Or Unpin the Note 
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public NotesModel PinorUnpinNote(int id, long TokenId)
        {
            try
            {
                var validUserId = this.context.UserTable.Where(e => e.Id == TokenId);
                if (validUserId != null)
                {
                    var pinNotes = this.context.NotesTable.FirstOrDefault(e => e.NotesId == id && e.IsPin == false);
                    if (pinNotes != null)
                    {
                        pinNotes.IsPin = true;
                        this.context.SaveChanges();
                        var pinn = this.context.NotesTable.FirstOrDefault(e => e.NotesId == id && e.Id == TokenId && e.IsPin == true);
                        if (pinn != null)
                        {
                            NotesModel model = new()
                            {
                                Id = pinn.Id,
                                NotesId = pinn.NotesId,
                                Title = pinn.Title,
                                Message = pinn.Message,
                                Color = pinn.Color,
                                Image = pinn.Image,
                                IsPin = pinn.IsPin,
                                IsArchive = pinn.IsArchive,
                                IsTrash = pinn.IsTrash,
                                Createat = pinn.Createat,
                                Modifiedat = pinn.Modifiedat
                            };
                            return model;
                        }
                    }
                    var unPinNotes = this.context.NotesTable.FirstOrDefault(e => e.NotesId == id && e.IsPin == true);
                    if (unPinNotes != null)
                    {
                        unPinNotes.IsPin = false;
                        this.context.SaveChanges();
                        var unpinn = this.context.NotesTable.FirstOrDefault(e => e.NotesId == id && e.Id == TokenId && e.IsPin == false);
                        if (unpinn != null)
                        {
                            NotesModel model = new()
                            {
                                Id = unpinn.Id,
                                NotesId = unpinn.NotesId,
                                Title = unpinn.Title,
                                Message = unpinn.Message,
                                Color = unpinn.Color,
                                Image = unpinn.Image,
                                IsPin = unpinn.IsPin,
                                IsArchive = unpinn.IsArchive,
                                IsTrash = unpinn.IsTrash,
                                Createat = unpinn.Createat,
                                Modifiedat = unpinn.Modifiedat
                            };
                            return model;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// Method to Archive or unarchive the note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string ArchiveOrUnArchieveNote(int id)
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
                if (note == true)
                {
                    var unarchiveNote = this.context.NotesTable.FirstOrDefault(x => x.NotesId == id).IsArchive == false;
                    var unarchiveThisNote = context.NotesTable.FirstOrDefault(u => u.NotesId == id);
                    unarchiveThisNote.IsArchive = unarchiveNote;
                    this.context.SaveChanges();
                    message = "Note Unarchived";
                    return message;
                }

                return message = "Unable to unarchive note.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        /// <summary>
        /// Method to Trash Or Restore Note
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>string message</returns>
        public string TrashOrRestoreNote(int id)
        {
            try
            {
                string message;
                var note = this.context.NotesTable.Where(x => x.NotesId == id).SingleOrDefault();
                if (note != null)
                {
                    if (note.IsTrash == false)
                    {
                        note.IsTrash = true;
                        this.context.Entry(note).State = EntityState.Modified;
                        this.context.SaveChanges();
                        message = "Note Restored";
                        return message;
                    }
                    if (note.IsTrash == true)
                    {
                        note.IsTrash = false;
                        this.context.Entry(note).State = EntityState.Modified;
                        this.context.SaveChanges();
                        message = "Note Trashed";
                        return message;
                    }
                }

                return message = "Unable to Restore or Trash note.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Method to add color for note
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="color">color name</param>
        /// <returns>string message</returns>
        public string AddColor(long id, string color)
        {
            try
            {
                string message;
                var note = this.context.NotesTable.Find(id);
                if (note != null)
                {
                    note.Color = color;
                    this.context.Entry(note).State = EntityState.Modified;
                    this.context.SaveChanges();
                    message = "Color added Successfully for note !";
                    return message;
                }

                return message = "Error While adding color for this note";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Images the notes.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="imageNotes">The image notes.</param>
        /// <param name="image">The image.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public void ImageNotes(Notes imageNotes, IFormFile image, long TokenId)
        {
            try
            {
                var validUserId = this.context.UserTable.Where(e => e.Id == TokenId);
                if (validUserId != null)
                {                                 
                        Account account = new Account(_config["Cloudinary:CloudName"], _config["Cloudinary:APIKey"], _config["Cloudinary:APISecret"]);
                        var imagePath = image.OpenReadStream();
                        Cloudinary cloudinary = new Cloudinary(account);
                        ImageUploadParams imageParams = new ImageUploadParams()
                        {
                            File = new FileDescription(image.FileName, imagePath)
                        };
                        var uploadImage = cloudinary.Upload(imageParams).Url.ToString();
                        imageNotes.Image = uploadImage;
                        this.context.SaveChanges();                                          
                }                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }        
}
