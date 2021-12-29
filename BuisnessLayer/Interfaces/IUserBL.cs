using CommonLayer.models;
using CommonLayer.Models;
using RepositoryLayer.Entities;
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
        public UserLoginResponse GetLoginData(UserLogin User1);
    }
}
