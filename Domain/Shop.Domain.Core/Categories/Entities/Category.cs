using Shop.Core.Domain.Photos.Entities;
using Shop.Framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.Core.Domain.Categories.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        
        public long? ParentId { get; set; }
        public Category Parent { get; set; }
        public List<Category> Children { get; set; }
        
        
        
        public long PhotoId { get; set; }
        public Photo Photo { get; set; }

    }
}
