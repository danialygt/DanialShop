using Shop.Core.Domain.Masters.Dto;
using Shop.Core.Domain.Masters.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Core.Domain.Carts
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public virtual void AddItem(DtoProductDetail product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product.Id == product.Id).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(DtoProductDetail product)
        {
            lineCollection.RemoveAll(l => l.Product.Id == product.Id);
        }

        public virtual decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }
}
