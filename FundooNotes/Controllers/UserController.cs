using BuisnessLayer.interfaces;
using BuisnessLayer.services;
using CommonLayer.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RepositoryLayer.Services;
using RepositoryLayer.interfaces;
using RepositoryLayer.Entities;
using CommonLayer.Models;

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
        /// Login of user using emailid and password
        /// </summary>
        /// <param name="user1"></param>
        /// <returns></returns>
        [HttpPost("LoginInfo")]

        public IActionResult GetLoginData(UserLogin user1)
        {
            try
            {
                UserLoginResponse result = this.bl.GetLoginData(user1);
                if (result == null)
                {
                    return this.BadRequest(new { Success = false, message = "Registration Unsuccessful" });
                   

                }
                else
                {
                    return this.Ok(new { Success = true, message = "User Login Successfull", UserInfo = result });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }
        /// <summary>
        /// Controller method for Forgot password method 
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>Response from API</returns>
        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            var result = this.bl.ForgotPassword(email);
            if (result.Equals("Mail Sent Successfully !"))
            {
                return this.Ok(new { success = true, Message = "The link is send to the given email address to reset the password", Data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Unable to sent link to given email address. This Email doesn't exist in database." });
            }
        }

        ///// <summary>
        ///// Controller method for Reset password method
        ///// </summary>
        ///// <param name="resetPassword"></param>
        ///// <returns></returns>
        //[HttpPut]
        //[Route("ResetPassword")]
        //public IActionResult ResetPassword(ChangePasswordModel resetPassword)
        //{
        //    string emailid = User.FindFirst("EmailId").Value;
        //    var result = this.bl.ResetPassword(resetPassword,emailid);
        //    if (result.Equals("Password Reset Successfull ! "))
        //    {
        //        return this.Ok(new { success = true, Message = "Password Reset Successfully", Data = result });
        //    }
        //    else
        //    {
        //        return this.BadRequest(new { success = false, Message = "Failed to Reset Password. This Email does not exis in database." });
        //    }
        //}
    }
}
