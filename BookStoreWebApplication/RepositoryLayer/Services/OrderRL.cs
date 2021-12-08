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
    public class OrderRL : IOrderRL
    {
        private readonly ApplicationDBContext applicationDBContext;
        public OrderRL(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public async Task<Order> PlaceOrder(Order summary)
        {
            try
            {
                
                this.applicationDBContext.Orders.Add(summary);
                var result = this.applicationDBContext.SaveChangesAsync();
                return await applicationDBContext.Orders.Where(u => u.UserId == summary.UserId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
} 