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
        IUserBL bl;
        string key = "My secret key";

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

        [HttpPut("UpdateId/{id}")]
        public IActionResult Update(long id, [FromBody] User user)
        {
            try
            {
                User updateUser = bl.GetWithId(id);
                if (updateUser == null)
                {
                    return BadRequest(new { Success = false, message = "No User Found With Id" });
                }
                bl.Update(updateUser, user);
                return Ok(new { Success = true, message = "Update Sucessful" });
            }
            catch (Exception)
            {
                throw;
            }
        }

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
                //User credentials = userBL.GetLoginData(user1.EmailId, user1.Password);
                if (result == null)
                {
                    return BadRequest(new { success = false, message = "email and password found" });
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user1.EmailId),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(new { Success = true, message = "Login Successful", JwtToken=tokenHandler.WriteToken(token)});
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
