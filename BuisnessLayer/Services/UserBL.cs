using BuisnessLayer.interfaces;
using CommonLayer.models;
using RepositoryLayer.Entity;
using RepositoryLayer.interfaces;
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
            // throw new NotImplementedException();
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

    }
}
