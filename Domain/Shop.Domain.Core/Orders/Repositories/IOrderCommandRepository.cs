using Shop.Core.Domain.Orders.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Orders.Repositories
{
    public interface IOrderCommandRepository
    {
        void Add(Order order);
        Order Find(long orderId);
        void Save();
    }


}
