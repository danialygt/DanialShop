using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Masters.Dto
{
    public class DtoGetAllMaster
    {
        public long Id { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public int NumberOfProducts { get; set; }
        public string ShortDescription { get; set; }

    }
}
