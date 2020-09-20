using Shop.Core.Domain.Masters.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Masters.Dto
{
    public class DtoMasterDetail
    {
        public long Id { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MasterProduct> MasterProducts { get; set; }
        
    }
}
