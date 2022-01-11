using BuisnessLayer.Interfaces;
using BuisnessLayer.Services;
using CommonLayer.Models.Lable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
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
        /// Controller for Creates the lable.
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
                return BadRequest(new { Success = false, Message = "No Notes With Particular NotesId", Exception_Message = ex.Message, InnerException = ex.InnerException });
            }
        }

        /// <summary>
        /// Controller for Get all lable.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllLable()
        {
            try
            {
                long TokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                LableResponseModel lable = bl.GetAllLable(TokenId);
                if (lable == null)
                {
                    return BadRequest(new { Success = false, message = "No lable in database " });
                }
                return Ok(new { Success = true, message = "Retrived All lables ", lable });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }

        /// <summary>
        /// Controller for Get the lable with identifier.
        /// </summary>
        /// <param name="lableId">The lable identifier.</param>
        /// <returns></returns>
        [HttpGet("{lableId}")]
        public IActionResult GetLableId(long lableId)
        {
            try
            {
                long TokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                LableResponseModel lable = bl.GetLableId(lableId, TokenId);
                if (lable == null)
                {
                    return BadRequest(new { Success = false, message = "No Lable With Particular LableId " });
                }
                return Ok(new { Success = true, message = "Retrived Lable ", lable });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }

        /// <summary>
        /// Controller for Updates the lable.
        /// </summary>
        /// <param name="lableId">The lable identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut("{lableId}")]
        public IActionResult UpdateLable(long lableId, LableModel model)
        {
            try
            {
                long TokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                Lable updateLable = bl.GetLablesWithId(lableId, TokenId);
                if (updateLable == null)
                {
                    return BadRequest(new { Success = false, message = "No Notes Found With NotesId" });
                }
                bl.UpdateLable(updateLable, model, TokenId);
                return Ok(new { Success = true, message = "Lable Updated Sucessfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }

        /// <summary>
        /// Controller for Deleting the lable.
        /// </summary>
        /// <param name="lableId">The lable identifier.</param>
        /// <returns></returns>
        [HttpDelete("{lableId}")]
        public IActionResult DeleteLable(long lableId)
        {
            try
            {
                long TokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                Lable lable = bl.GetLablesWithId(lableId, TokenId);
                if (lable == null)
                {
                    return BadRequest(new { Success = false, message = "No Lable Found" });
                }
                bl.DeleteLable(lable, TokenId);
                return Ok(new { Success = true, message = "Lable Removed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }

        /// <summary>
        /// Controller for Adding the lable.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut("AddLable")]
        public IActionResult AddLable(LableModel model)
        {
            try
            {
                long TokenId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                if (TokenId == 0)
                {
                    return BadRequest(new { Success = false, message = "No Notes Found With NotesId" });
                }
                Lable addLable = bl.AddLable(model, TokenId);
                return Ok(new { Success = true, message = "Lable Updated Sucessfully", addLable });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message, InnerException = ex.InnerException });
            }
        }
    }
}

