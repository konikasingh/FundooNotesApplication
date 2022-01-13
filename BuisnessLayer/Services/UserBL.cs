using BuisnessLayer.interfaces;
using CommonLayer.models;
using CommonLayer.Models;
using RepositoryLayer.Entities;
using RepositoryLayer.interfaces;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.services
{
    public class UserBL : IUserBL
    {
        IUserRL UserRL;
        public UserBL(IUserRL userRL)
        {
            this.UserRL = userRL;
        }
        public bool Registration(UserRegistration user)
        {
            try
            {
                return this.UserRL.Registration(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> GetUserRegistration()
        {
            return this.UserRL.GetUserRegistration();
        }
        public UserLoginResponse GetLoginData(UserLogin User1)
        {
            try
            {
                return this.UserRL.GetLoginData(User1);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Forgot password Method 
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>string message</returns>
        public string ForgotPassword(string email)
        {
           
             string message = this.UserRL.ForgotPassword(email);
             return message;
        }

        public string ResetPassword(ChangePasswordModel resetPassword, string emailid)
        {
            string message = this.UserRL.ResetPassword(resetPassword, emailid);
            return message;
        }
    }
}
    

