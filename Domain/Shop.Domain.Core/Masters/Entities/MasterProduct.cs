using Shop.Core.Domain.Categories.Entities;
using Shop.Core.Domain.Photos.Entities;
using Shop.Framework.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Core.Domain.Masters.Entities
{
    public class MasterProduct : BaseEntity
    {
        public string Name { get; set; }
        public long Price { get; set; }
        public long Discount { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }



        public long MasterId { get; set; }

        public Master Master { get; set; }

        public long CategoryId { get; set; }

        public Category Category { get; set; }
   
        public List<Photo> Photos { get; set; }
    }
}
