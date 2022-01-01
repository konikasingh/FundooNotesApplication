using BuisnessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
using System;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        INotesBL bl;     //create the object of IUserBL class
        public NotesController(INotesBL bl)
        {
            this.bl = bl;
        }
        [Authorize]            //It will authorize the post api of notes
        [HttpPost]
        public IActionResult CreateNotes(NotesModel client)
        {
            try
            {
                if (this.bl.CreateNotes(client))
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
        

        [HttpGet("GetAllNotesData")]
        public IActionResult GetNotesDetail()
        {
            try
            {
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
        
        [HttpGet("GetWithId/{id}")]
        public IActionResult GetWithId(long id)
        {
            try
            {
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
       
        [HttpPut("UpdateId/{id}")]
        public IActionResult UpdateNotes(long id, Notes note)
        {
            try
            {
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
       
        [HttpDelete("DeleteWithId/{id}")]
        public IActionResult DeleteNotes(long id)
        {
            try
            {
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
    }
}
