using BussinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public async Task<User> UserRegistration(User user)
        {
            try
            {
                return await userRL.UserRegistration(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<User> UserLogin(UserLogin userLogin)
        {
            try
            {
                return await userRL.UserLogin(userLogin);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
