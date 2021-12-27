using CommonLayer.models;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Getting details of user (API)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetUserRegistration()
        {
            return context.UserTable.ToList();
        }

        public User GetWithId(long id)
        {
            try
            {
                return this.context.UserTable.FirstOrDefault(i => i.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(User AClient, User client)
        {
            try
            {
                AClient.FirstName = client.FirstName;
                AClient.LastName = client.LastName;
                AClient.EmailId = client.EmailId;
                AClient.Password = client.Password;
                AClient.Modifiedat = client.Modifiedat;
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(User client)
        {
            try
            {
                this.context.UserTable.Remove(client);
                this.context.SaveChanges();

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
        public UserLogin GetLoginData(UserLogin User1)
        {
            try
            {
                 var ValidLogin = this.context.UserTable.Where(X => X.EmailId == User1.EmailId && X.Password == User1.Password).FirstOrDefault();
                 if(ValidLogin != null)
                 {
                    return User1;
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
        }
    }
}