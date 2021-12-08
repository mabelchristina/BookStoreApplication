using BussinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class OrderBL:IOrderBL
    {
        private readonly IOrderRL orderRL;
        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }

        async public Task<Order> PlaceOrder(Order summary)
        {
            try
            {
                return await orderRL.PlaceOrder(summary);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
