using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        Task<User> UserRegistration(User user);
        Task<User> UserLogin(UserLogin userLogin);
    }
}
