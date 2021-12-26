using CommonLayer.models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.interfaces
{
    public interface IUserBL
    {
        public bool Registration(UserRegistration user);

        IEnumerable<User> GetUserRegistration();

        public UserLogin GetLoginData(UserLogin User1);
    }
}
