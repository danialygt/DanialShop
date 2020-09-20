using Shop.Core.Domain.Masters.Entities;
using Shop.Framework.Domain;

namespace Shop.Core.Domain.Orders.Entities
{
    public class OrderLine : BaseEntity
    {
        public Order Order { get; set; }
        public long OrderId { get; set; }
        public long MasterProductId { get; set; }
        public MasterProduct MasterProduct { get; set; }
        public int Count { get; set; }
        public long Price { get; set; }
        public long Discount { get; set; }

    }
}
