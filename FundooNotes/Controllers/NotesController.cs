﻿using BuisnessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
using System;
using System.Linq;

namespace FundooNotes.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        INotesBL bl;     //create the object of IUserBL class
        public NotesController(INotesBL bl)
        {
            this.bl = bl;
        }
        /// <summary>
        /// Controller Method call method CreateNote() method to Create the note
        /// </summary>
        /// <param name="client">note id</param>
        /// <returns>message</returns>
                  
        [HttpPost]
        public IActionResult CreateNotes(NotesModel client)
        {
            try
            {
                long tokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                if (this.bl.CreateNotes(client, tokenId))
                {
                    return this.Ok(new { Success = true, message = "Note Created" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "No notes are there" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Controller Method call method GetAllNote() method to Get the note
        /// </summary>
        /// <param name="">note id</param>
        /// <returns>string message</returns>
        [HttpGet("GetAllNotesData")]
        public IActionResult GetNotesDetail()
        {
            try
            {
                long tokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var notesDetails = this.bl.GetNotesDetail();
                if (notesDetails != null)
                {
                    return this.Ok(new { Success = true, userInformation = notesDetails });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "No Notes Are There: " });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }
        /// <summary>
        /// Controller Method call method GetWithId() method to Get the note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>message</returns>
        [HttpGet("GetWithId")]
        public IActionResult GetWithId(long id)
        {
            try
            {
                long tokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                Notes note = bl.GetWithId(id);
                if (note == null)
                {
                    return BadRequest(new { Success = false, message = "No Notes With Particular Id " });
                }
                return Ok(new { Success = true, message = "Notes Available with Entered Id ", note });
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Controller Method call method UpdateNote() method to Update the note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>message</returns>
        [HttpPut("UpdateId")]
        public IActionResult UpdateNotes(long id, Notes note)
        {
            try
            {
                long tokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                Notes updateNotes = bl.GetWithId(id);
                if (updateNotes == null)
                {
                    return BadRequest(new { Success = false, message = "No Notes are there with this Id" });
                }
                bl.UpdateNotes(updateNotes, note);
                return Ok(new { Success = true, message = "Update Sucessful" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Controller Method call method DeleteNote() method to Delete the note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        [HttpDelete("DeleteWithId")]
        public IActionResult DeleteNotes(long id)
        {
            try
            {
                long tokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                Notes note = bl.GetWithId(id);
                if (note == null)
                {
                    return BadRequest(new { Success = false, message = "Notes with entered id not found" });
                }
                bl.DeleteNotes(note);
                return Ok(new { Success = true, message = "Notes Deleted From DataBase" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Controller Method call method PinNote() method to Pin the note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        [HttpPut]
        [Route("PinNote")]
        public IActionResult PinNote(int id)
        {
            try
            {
                long tokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = this.bl.PinNote(id);
                if (result != null)
                {
                    return this.Ok(new  { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new  { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new  { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller Method call method UnpinNote() method to unpin the note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        [HttpPut]
        [Route("UnpinNote")]
        public IActionResult UnpinNote(int id)
        {
            try
            {
                long tokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = this.bl.UnpinNote(id);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller Method call method ArchiveNote() method to Archive  the note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ArchiveNote")]
        public IActionResult ArchiveNote(int id)
        {
            try
            {
                long tokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = this.bl.ArchiveNote(id);
                if (result != null)
                {
                    return this.Ok(new  { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new  { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new  { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Controller Method call method UnarchiveNote() method to Unarchive the note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UnarchiveNote")]
        public IActionResult UnarchiveNote(int id)
        {
            try
            {
                var result = this.bl.UnarchiveNote(id);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Controller method to Trash Or Restore a Note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        [HttpPut]
        [Route("TrashOrRestoreNote")]
        public IActionResult TrashOrRestoreNote(int id)
        {
            try
            {
                long tokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = this.bl.TrashOrRestoreNote(id);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Controller method to add color for note
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="color">color name</param>
        /// <returns></returns>
        [HttpPut]
        [Route("addColor")]
        public IActionResult ChangeColor(long id, string color)
        {
            try
            {
                long tokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var message = this.bl.AddColor(id, color);
                if (message.Equals("New Color has set to this note !"))
                {
                    return this.Ok(new { Status = true, Message = message, Data = color });
                }

                return this.BadRequest(new { Status = true, Message = message });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        

    }
}
