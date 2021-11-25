using CommonModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserBL
    {
        Task<int> Register(User user);
        public User Login(UserLogin login);
    }
}
