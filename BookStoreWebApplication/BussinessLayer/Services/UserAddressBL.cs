using BussinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class UserAddressBL : IUserAddressBL
    {
        private readonly IUserAddressRL userAddressRL;
        public UserAddressBL(IUserAddressRL userAddressRL)
        {
            this.userAddressRL = userAddressRL;
        }

        async Task<List<UserAddress>> IUserAddressBL.DeleteAddress(int userId)
        {
            try
            {
                return await userAddressRL.DeleteAddress(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        async Task<UserAddress> IUserAddressBL.AddUserAddress( UserAddress userAddresses)
        {
            try
            {
                return await userAddressRL.AddUserAddress(userAddresses);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<List<UserAddress>> IUserAddressBL.GetAllAddresses(int userId)
        {
            try
            {
                return await userAddressRL.GetAllAddresses(userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
