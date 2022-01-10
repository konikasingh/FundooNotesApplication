using BuisnessLayer.Interfaces;
using BuisnessLayer.Services;
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
    public class CollaboratorController : ControllerBase
    {
        ICollaboratorBL bl;     //create the object of IUserBL class
        public CollaboratorController(ICollaboratorBL bl)
        {
            this.bl = bl;
        }
        /// <summary>
        /// Controller for Collaborator to add the collaborator 
        /// </summary>
        /// <param name="notesId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Collaborate/{notesId}")]
        public IActionResult AddCollaborate(long notesId, CollaboratorModel model)
        {
            try
            {
                long TokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                if (TokenId == 0 && notesId == 0)
                {
                    return BadRequest(new { Success = false, message = "Email Missing For Collaboration" });
                }
                bl.AddCollaborate(notesId, TokenId, model);
                return Ok(new { Success = true, message = "Collaboration Successfull " });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = "No Notes With Particular NotesId", Exception_Message = ex.Message, StackTraceException = ex.StackTrace });
            }
        }

        /// <summary>
        /// Controller for Collaborator to delete the collaborator 
        /// </summary>
        /// <param name="collabId"></param>
        /// <returns></returns>
        [HttpDelete("{collabId}")]
        public IActionResult DeleteCollaborate(long collabId)
        {
            try
            {
                Collaborate collab = bl.GetCollabtrWithId(collabId);
                if (collab == null)
                {
                    return BadRequest(new { Success = false, message = "No Collaboration Found" });
                }
                bl.DeleteCollabtr(collab);
                return Ok(new { Success = true, message = "Collaborated Email Removed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message, StackTraceException = ex.StackTrace });
            }
        }
    }
}
