using BuisnessLayer.interfaces;
using CommonLayer.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
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
        /// <summary>
        /// Registration of user using all credentials
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Getting the data of all the registered user
        /// </summary>
        /// <returns></returns>

        [HttpGet("GetAllUserData")]
        public IActionResult GetAllUserData()
        {
            try
            {
                var userDetails = this.bl.GetUserRegistration();
                if (userDetails != null)
                {
                    return this.Ok(new { Success = true, userInformation = userDetails });
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
        /// <summary>
        /// Login of user using emailid and password
        /// </summary>
        /// <param name="user1"></param>
        /// <returns></returns>
        [HttpPost("LoginInfo")]
        public IActionResult GetLoginData(UserLogin user1)
        {
            try
            {
                UserLogin result = this.bl.GetLoginData(user1);
                if (result == null)
                {
                    return this.BadRequest(new { Success = false, message = "Registration Unsuccessful" });
                    
                }
                else
                {
                    return this.Ok(new { Success = true, message = "User Login Successfull" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
