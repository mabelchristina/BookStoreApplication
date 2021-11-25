using BusinessLogic.Interfaces;
using CommonModel.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserBL:IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        Task<int> IUserBL.Register(User user)
        {
            try
            {
                var result = this.userRL.Register(user);
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
         User IUserBL.Login(UserLogin login)
        {
            try
            {
                var result = this.userRL.Login(login);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
