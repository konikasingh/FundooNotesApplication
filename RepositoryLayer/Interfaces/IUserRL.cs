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
        public UserLoginResponse GetLoginData(UserLogin User1);
        public string ForgotPassword(string email);
       // public string ResetPassword(ChangePasswordModel resetPassword, string emailid);
    }
}
