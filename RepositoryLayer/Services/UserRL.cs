using CommonLayer.models;
using CommonLayer.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Entities;
using RepositoryLayer.interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
                newUser.Password = user.Password;
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
                var ValidLogin = this.context.UserTable.Where(X => X.EmailId == User1.EmailId && X.Password == User1.Password).FirstOrDefault();
                if (ValidLogin != null)
                {
                    token = GenerateJWTToken(ValidLogin.EmailId);
                    logResponse.token = token;
                    //return User1;
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
            return logResponse;
        }

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

        public string encryptpass(string Password)
        {
            string msg = "";
            byte[] encode = new byte[Password.Length];
            encode = Encoding.UTF8.GetBytes(Password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }
        
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
    }
}