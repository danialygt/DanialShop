using Shop.Core.Domain.Customers.Entities;
using Shop.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Orders.Entities
{
    public class Order : BaseEntity
    {
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
