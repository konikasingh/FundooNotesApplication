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
    }
}
