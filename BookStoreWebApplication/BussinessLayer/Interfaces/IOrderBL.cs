using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IOrderBL
    {
        Task<Order> PlaceOrder(Order summary);
    }
}
