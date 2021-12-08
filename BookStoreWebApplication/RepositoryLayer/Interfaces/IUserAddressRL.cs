using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IUserAddressRL
    {
       Task<UserAddress> AddUserAddress( UserAddress userAddresses);
        Task<List<UserAddress>> GetAllAddresses(int userId);
        Task<List<UserAddress>> DeleteAddress(int userId);
    }
}
