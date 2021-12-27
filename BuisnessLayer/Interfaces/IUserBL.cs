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

         public User GetWithId(long id);

        public void Update(User AClient, User client);

        public void Delete(User client);

        public UserLogin GetLoginData(UserLogin User1);

    }
}
