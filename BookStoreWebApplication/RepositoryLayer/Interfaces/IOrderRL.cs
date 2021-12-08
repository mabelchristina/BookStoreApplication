using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IOrderRL
    {
        Task<Order> PlaceOrder(Order summary);
    }
}
