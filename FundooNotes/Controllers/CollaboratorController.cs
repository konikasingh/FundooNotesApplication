using BuisnessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FundooNotes.Controllers
{
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
        /// Added the collaborator
        /// </summary>
        /// <param name="collaboraters"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddCollaborator(CollaboratorModel collaboraters)
        {
            try
            {
                var message = this.bl.AddCollaborator(collaboraters);
                if (message.Equals("New Collaborator added Successfully !"))
                {
                    return this.Ok(new { Status = true, Message = message, Data = collaboraters });
                }

                return this.BadRequest(new { Status = false, Message = message });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult RemoveCollaborator(long id)
        {
            try
            {
                var message = this.bl.DeleteCollaborator(id);
                if (message.Equals("Collaborator Deleted Successfully !"))
                {
                    return this.Ok(new { Status = true, Message = message, Data = id });
                }

                return this.BadRequest(new { Status = false, Message = message });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult RetrieveAllCollaborator()
        {
            try
            {
                var result = this.bl.GetCollaborators();
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Collaborators Retrieved Successfully !", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Unable to retrieve Collaborators" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
    }
}
