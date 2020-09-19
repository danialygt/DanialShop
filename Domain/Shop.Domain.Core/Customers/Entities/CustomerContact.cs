using Shop.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Customers.Entities
{
    public class CustomerContact:BaseEntity
    {
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Provience { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
