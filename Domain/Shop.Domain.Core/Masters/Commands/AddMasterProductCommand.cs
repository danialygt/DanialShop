using Shop.Core.Domain.Photos.Entities;
using Shop.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Masters.Commands
{
    public  class AddMasterProductCommand:ICommand
    {
        public long MasterId { get; set; }
        public long CategoryId { get; set; }

        public string Name { get; set; }
        public long Price { get; set; }
        public long Discount { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public List<string> Photos { get; set; }
    }
}
