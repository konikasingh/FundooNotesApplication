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
        public NotesModel ArchiveOrUnArchieveNote(int id, long TokenId)
        {
            try
            {
                var validUserId = this.context.UserTable.Where(e => e.Id == TokenId);
                if (validUserId != null)
                {
                    var ArchiveNotes = this.context.NotesTable.FirstOrDefault(e => e.NotesId == id && e.IsArchive == false);
                    if (ArchiveNotes != null)
                    {
                        ArchiveNotes.IsArchive = true;
                        this.context.SaveChanges();
                        var archi = this.context.NotesTable.FirstOrDefault(e => e.NotesId == id && e.Id == TokenId && e.IsArchive == true);
                        if (archi != null)
                        {
                            NotesModel model = new()
                            {
                                Id = archi.Id,
                                NotesId = archi.NotesId,
                                Title = archi.Title,
                                Message = archi.Message,
                                Color = archi.Color,
                                Image = archi.Image,
                                IsPin = archi.IsPin,
                                IsArchive = archi.IsArchive,
                                IsTrash = archi.IsTrash,
                                Createat = archi.Createat,
                                Modifiedat = archi.Modifiedat
                            };
                            return model;
                        }
                    }
                    var unArchiveNotes = this.context.NotesTable.FirstOrDefault(e => e.NotesId == id && e.IsArchive == true);
                    if (unArchiveNotes != null)
                    {
                        unArchiveNotes.IsArchive = false;
                        this.context.SaveChanges();
                        var unarchi = this.context.NotesTable.FirstOrDefault(e => e.NotesId == id && e.Id == TokenId && e.IsArchive == false);
                        if (unarchi != null)
                        {
                            NotesModel model = new()
                            {
                                Id = unarchi.Id,
                                NotesId = unarchi.NotesId,
                                Title = unarchi.Title,
                                Message = unarchi.Message,
                                Color = unarchi.Color,
                                Image = unarchi.Image,
                                IsPin = unarchi.IsPin,
                                IsArchive = unarchi.IsArchive,
                                IsTrash = unarchi.IsTrash,
                                Createat = unarchi.Createat,
                                Modifiedat = unarchi.Modifiedat
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
        /// Method to Trash Or Restore Note
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>string message</returns>
        public NotesModel TrashOrRestoreNote(int id, long TokenId)
        {
            try
            {
                var validUserId = this.context.UserTable.Where(e => e.Id == TokenId);
                if (validUserId != null)
                {
                    var TrashNotes = this.context.NotesTable.FirstOrDefault(e => e.NotesId == id && e.IsTrash == false);
                    if (TrashNotes != null)
                    {
                        TrashNotes.IsTrash = true;
                        this.context.SaveChanges();
                        var del = this.context.NotesTable.FirstOrDefault(e => e.NotesId == id && e.Id == TokenId && e.IsTrash == true);
                        if (del != null)
                        {
                            NotesModel model = new()
                            {
                                Id = del.Id,
                                NotesId = del.NotesId,
                                Title = del.Title,
                                Message = del.Message,
                                Color = del.Color,
                                Image = del.Image,
                                IsPin = del.IsPin,
                                IsArchive = del.IsArchive,
                                IsTrash = del.IsTrash,
                                Createat = del.Createat,
                                Modifiedat = del.Modifiedat
                            };
                            return model;
                        }
                    }
                    var RestroreNotes = this.context.NotesTable.FirstOrDefault(e => e.NotesId == id && e.IsTrash == true);
                    if (RestroreNotes != null)
                    {
                        RestroreNotes.IsTrash = false;
                        this.context.SaveChanges();
                        var restor = this.context.NotesTable.FirstOrDefault(e => e.NotesId == id && e.Id == TokenId && e.IsTrash == false);
                        if (restor != null)
                        {
                            NotesModel model = new()
                            {
                                Id = restor.Id,
                                NotesId = restor.NotesId,
                                Title = restor.Title,
                                Message = restor.Message,
                                Color = restor.Color,
                                Image = restor.Image,
                                IsPin = restor.IsPin,
                                IsArchive = restor.IsArchive,
                                IsTrash = restor.IsTrash,
                                Createat = restor.Createat,
                                Modifiedat = restor.Modifiedat
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
