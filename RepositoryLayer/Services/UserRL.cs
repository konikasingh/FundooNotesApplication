using CommonLayer.models;
using CommonLayer.Models;
using Experimental.System.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Entities;
using RepositoryLayer.interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;


namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        ucontext context;

        public UserRL(ucontext context)
        {
            this.context = context;
        }

        private const string Key = "this is my sample key";
        
        /// <summary>
        /// Register the user (API) 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Registration(UserRegistration user)
        {
            try
            {
                User newUser = new User();
                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.Password = encryptpass(user.Password);
                newUser.EmailId = user.EmailId;
                this.context.UserTable.Add(newUser);

                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        /// <summary>
        /// login of user with emailid and password
        /// </summary>
        /// <param name="User1"></param>
        /// <returns></returns>
        public UserLoginResponse GetLoginData(UserLogin User1)
        {
            UserLoginResponse logResponse = new UserLoginResponse();
            string token = "";

            try
            {
                var ValidLogin = this.context.UserTable.Where(X => X.EmailId == User1.EmailId).FirstOrDefault();

                if (Decryptpass(ValidLogin.Password) == User1.Password)
                {
                    token = GenerateJWTToken(ValidLogin.EmailId);
                    logResponse.token = token;
                    return logResponse;
                }
                else
                {
                    return null;
                }

            }
            catch (ArgumentException)
            {
                throw;
            }
            //return logResponse;
        }
        /// <summary>
        /// it will generate the token for particular user who login with valid emailid and password
        /// </summary>
        /// <param name="EmailId"></param>
        /// <returns></returns>
        private string GenerateJWTToken(string EmailId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
            new Claim("EmailId",EmailId)
            };
            var token = new JwtSecurityToken("Konika", EmailId,
              claims,
              expires: DateTime.Now.AddMinutes(20),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        /// <summary>
        /// it will encrypt the password field
        /// </summary>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static string encryptpass(string Password)
        {

            byte[] encode = new byte[Password.Length];
            encode = Encoding.UTF8.GetBytes(Password);
            string msg = Convert.ToBase64String(encode);
            return msg;
        }
        /// <summary>
        /// it will decrypt the password field
        /// </summary>
        /// <param name="encryptpwd"></param>
        /// <returns></returns>
        private string Decryptpass(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }

        /// <summary>
        /// Method to Implement Forgot password functionality.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>string message</returns>
        public string ForgotPassword(string email)
        {
            var url = "Click on following link to reset the password for FundooNotes App: https://localhost:44354/User/api/ResetPassword.html";
            MessageQueue msmqQueue = new MessageQueue();
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
            {
                msmqQueue = new MessageQueue(@".\Private$\MyQueue");
            }
            else
            {
                msmqQueue = MessageQueue.Create(@".\Private$\MyQueue");

            }
            Message message = new Message();
            message.Formatter = new BinaryMessageFormatter();
            message.Body = url;
            msmqQueue.Label = "url link";
            msmqQueue.Send(message);
            var reciever = new MessageQueue(@".\Private$\MyQueue");
            var recieving = reciever.Receive();
            recieving.Formatter = new BinaryMessageFormatter();
            string linkToBeSend = recieving.Body.ToString();

            string user;
            string mailSubject = "Link to reset your FundooNotes App Credentials";
            var userCheck = this.context.UserTable
                            .SingleOrDefault(x => x.EmailId == email);
            if (userCheck != null)
            {
                string Token = GenerateJWTToken(userCheck.EmailId);
                user = linkToBeSend;
                using (MailMessage mailMessage = new MailMessage("konikasingh1996@gmail.com", email))
                {
                    mailMessage.Subject = mailSubject;                
                    mailMessage.Body = Token;
                    mailMessage.IsBodyHtml = true;
                    SmtpClient Smtp = new SmtpClient();
                    Smtp.Host = "smtp.gmail.com";
                    Smtp.EnableSsl = true;
                    Smtp.UseDefaultCredentials = false;
                    Smtp.Credentials = new NetworkCredential("konikasingh1996@gmail.com", "Mahakaal@123");
                    Smtp.Port = 587;
                    Smtp.Send(mailMessage);
                }
                return "Mail Sent Successfully !";
            }
            else
            {
                return "Error while sending mail !";
            }
        }

        /// <summary>
        /// Method to reset old user password with new one.
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns>string message</returns>
        public string ResetPassword(ChangePasswordModel resetPassword)
        {
            var newPassword = this.context.UserTable
                            .SingleOrDefault(x => x.EmailId == resetPassword.EmailId);
            if (newPassword != null)
            {
                newPassword.Password = resetPassword.Password;
                context.Entry(newPassword).State = EntityState.Modified;
                context.SaveChanges();
                return "Password Reset Successfull ! ";
            }
            else
            {
                return "Error While Resetting Password !";
            }
        }
    }
}