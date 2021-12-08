using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class UserAddressRL:IUserAddressRL
    {
        private readonly ApplicationDBContext applicationDBContext;
        public UserAddressRL(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public async Task<UserAddress> AddUserAddress( UserAddress userAddresses)
        {
            try
            { 
                
                await this.applicationDBContext.UserAddresses.AddAsync(userAddresses);
                await this.applicationDBContext.SaveChangesAsync();
                return await applicationDBContext.UserAddresses.Where(u => u.UserId == userAddresses.UserId).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<UserAddress>> GetAllAddresses(int userId)
        {
            return await applicationDBContext.UserAddresses
                .Where(c => c.UserId == userId)
                .Join(applicationDBContext.Books,
                c => c.UserId,
                b => b.BookId,
                (c, b) => new UserAddress
                {
                    AddressId = c.AddressId,
                    UserId = c.UserId,
                    Address=c.Address,
                    Type = c.Type,
                    City = c.City,
                    State=c.State
                }).ToListAsync();
        }
        public async Task<List<UserAddress>> DeleteAddress(int userId)
        {
            var userAddr = await applicationDBContext.Carts.Where(c => c.UserId == userId ).FirstOrDefaultAsync();
            if (userAddr.Equals(null))
            {
                throw new Exception("No User address for this userid.");
            }
            applicationDBContext.Carts.Remove(userAddr);
            await applicationDBContext.SaveChangesAsync();
            return await applicationDBContext.UserAddresses
                .Where(c => c.UserId == userId)
                .Join(applicationDBContext.Books,
                c => c.UserId,
                b => b.BookId,
                (c, b) => new UserAddress
                {
                    AddressId = c.AddressId,
                    UserId = c.UserId,
                    Address = c.Address,
                    Type = c.Type,
                    City = c.City,
                    State = c.State
                }).ToListAsync();
        }
    }
}
