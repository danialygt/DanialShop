using Shop.Core.Domain.Orders.Entities;
using Shop.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Customers.Entities
{
    public class Customer:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public List<Order> Orders { get; set; }
        public List<Payment> Payments { get; set; }
        public List<CustomerContact> CustomerContacts { get; set; }
    }
}
