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

        public void Update(User AClient, User client)
        {
            try
            {
                this.UserRL.Update(AClient, client);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public User GetWithId(long id)
        {
            try
            {
                return this.UserRL.GetWithId(id);
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
                this.UserRL.Delete(client);
            }
            catch (Exception)
            {
                throw;
            }
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
    }
}
    

