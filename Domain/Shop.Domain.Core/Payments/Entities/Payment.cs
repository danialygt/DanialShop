using Shop.Core.Domain.Customers.Entities;
using Shop.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Payments.Entities
{
    public class Payment : BaseEntity
    {
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public long PaymentValue { get; set; }
        public DateTime PaymentDate { get; set; }
    }



}
