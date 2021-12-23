using BuisnessLayer.interfaces;
using CommonLayer.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL bl;
        public UserController(IUserBL bl)
        {
            this.bl = bl;
        }

        [HttpPost]
        public IActionResult UserRegistration(UserRegistration user)
        {
            try
            {
                if (this.bl.Registration(user))
                {
                    return this.Ok(new { Success = true, message = "Registration Successful" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Registration Unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("GetAllUserData")]
        public IActionResult GetAllUserData()
        {
            try
            {
                var userDetails = this.bl.GetUserRegistration();
                if (userDetails != null)
                {
                    return this.Ok(new { Success = true, userInformation = userDetails  });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "No Users Are There: " });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
