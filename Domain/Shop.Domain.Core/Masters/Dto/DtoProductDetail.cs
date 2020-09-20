using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Masters.Dto
{
    public class DtoProductDetail
    {

        public long Id { get; set; }
        public List<string> PhotosUrl { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string MasterName { get; set; }
        public long MasterId { get; set; }
        public long Price { get; set; }
        public long Discount { get; set; }
        public string Description { get; set; }


    }
}
