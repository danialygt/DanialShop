using Shop.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Orders.Queries
{
    public class GetByIdOrderQuery:IQuery
    {
        public long OrderId { get; set; }
    }
}
