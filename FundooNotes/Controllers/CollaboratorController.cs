//using BuisnessLayer.Interfaces;
//using CommonLayer.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;

//namespace FundooNotes.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CollaboratorController : ControllerBase
//    {
//        ICollaboratorBL bl;     //create the object of IUserBL class
//        public CollaboratorController(ICollaboratorBL bl)
//        {
//            this.bl = bl;
//        }
//        [HttpPost("Collaborate/{notesId}")]
//        public IActionResult AddCollaborate(long notesId, CollaborateModel model)
//        {
//            try
//            {
//                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
//                if (jwtUserId == 0 && notesId == 0)
//                {
//                    return BadRequest(new { Success = false, message = "Email Missing For Collaboration" });
//                }
//                collaborateBL.AddCollaborate(notesId, jwtUserId, model);
//                return Ok(new { Success = true, message = "Collaboration Successfull " });
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new { Success = false, Message = "No Notes With Particular NotesId", Exception_Message = ex.Message, StackTraceException = ex.StackTrace });
//            }
//        }

//        [HttpDelete("{collabId}")]
//        public IActionResult DeleteCollaborate(long collabId)
//        {
//            try
//            {
//                FundooCollaborate collab = collaborateBL.GetCollabWithId(collabId);
//                if (collab == null)
//                {
//                    return BadRequest(new { Success = false, message = "No Collaboration Found" });
//                }
//                collaborateBL.DeleteCollab(collab);
//                return Ok(new { Success = true, message = "Collaborated Email Removed" });
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new { Success = false, Message = ex.Message, StackTraceException = ex.StackTrace });
//            }
//        }
//    }
//}
