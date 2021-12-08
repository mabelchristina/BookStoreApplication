using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IUserBL
    {
        Task<User> UserRegistration(User user);
        Task<User> UserLogin(UserLogin userLogin);
    }
}
