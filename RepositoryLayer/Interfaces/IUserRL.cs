using CommonLayer.models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.interfaces
{
    public interface IUserRL
    {
        public bool Registration(UserRegistration User);

        IEnumerable<User> GetUserRegistration();

        public UserLogin GetLoginData(UserLogin User1);
    }
}
