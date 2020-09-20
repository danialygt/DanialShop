using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Masters.Dto
{
    public class DtoProduct
    {
        public long Id { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string MasterName { get; set; }
        public long MasterId { get; set; }


        public string CategoryName { get; set; }
        public long Price { get; set; }
        public long Discount { get; set; }


    }
}
