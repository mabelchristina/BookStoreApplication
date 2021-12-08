using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IUserAddressBL
    {
        Task<UserAddress> AddUserAddress(UserAddress userAddresses);
        Task<List<UserAddress>> GetAllAddresses(int userId);
        Task<List<UserAddress>> DeleteAddress(int userId);
    }
}
