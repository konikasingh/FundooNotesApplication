using BuisnessLayer.Interfaces;
using CommonLayer.Models.Lable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LableController : ControllerBase
    {
        ILableBL bl;     //create the object of IUserBL class
        public LableController(ILableBL bl)
        {
            this.bl = bl;
        }

        /// <summary>
        /// Creates the lable.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost("{notesId}")]
        public IActionResult CreateLable(long notesId, LableModel model)
        {
            try
            {
                long TokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                if (TokenId == 0 && notesId == 0)
                {
                    return BadRequest(new { Success = false, message = "Name Missing For Lable" });
                }
                LableResponseModel lable = bl.CreateLable(notesId, TokenId, model);
                return Ok(new { Success = true, message = "Lable Created", lable });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = "No Notes With Particular NotesId", Exception_Message = ex.Message, StackTraceException = ex.StackTrace });
            }
        }

    }
}

