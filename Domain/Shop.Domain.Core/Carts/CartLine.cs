using Shop.Core.Domain.Masters.Dto;
using Shop.Core.Domain.Masters.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Carts
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public DtoProduct Product { get; set; }
        public int Quantity { get; set; }


    }
}
