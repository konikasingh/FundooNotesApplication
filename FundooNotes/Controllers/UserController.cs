using BuisnessLayer.interfaces;
using BuisnessLayer.services;
using CommonLayer.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;
using RepositoryLayer.Entity;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RepositoryLayer.Services;
using RepositoryLayer.interfaces;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL bl;     //create the object of IUserBL class
        public UserController(IUserBL bl)
        {
            this.bl = bl;      //bl is the parameter of IuserBL
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
        /// Search User With UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetWithId/{id}")]
        public IActionResult GetWithId(long id)
        {
            try
            {
                User user = bl.GetWithId(id);
                if (user == null)
                {
                    return BadRequest(new { Success = false, message = "No User With Particular Id " });
                }
                return Ok(new { Success = true, message = "User Available with Entered Id ", user });
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update the particular user using userId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("UpdateId/{id}")]
        public IActionResult Update(long id, [FromBody] User user)
        {
            try
            {
                User updateUser = bl.GetWithId(id);
                if (updateUser == null)
                {
                    return BadRequest(new { Success = false, message = "No User are there with this Id" });
                }
                bl.Update(updateUser, user);
                return Ok(new { Success = true, message = "Update Sucessful" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete the user with uaing the UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteWithId/{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                User user = bl.GetWithId(id);
                if (user == null)
                {
                    return BadRequest(new { Success = false, message = "User with entered id not found" });
                }
                bl.Delete(user);
                return Ok(new { Success = true, message = "User Deleted From DataBase" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Login of user using emailid and password
        /// </summary>
        /// <param name="user1"></param>
        /// <returns></returns>
        [Authorize]
        [AllowAnonymous]
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
