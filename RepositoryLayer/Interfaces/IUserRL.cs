using CommonLayer.models;
using CommonLayer.Models;
using RepositoryLayer.Entities;
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
        public User GetWithId(long id);
        public void Update(User AClient, User client);
        public void Delete(User client);

        public UserLoginResponse GetLoginData(UserLogin User1);
        //public UserLogin Authenticate(UserLogin user1);
    }
}
