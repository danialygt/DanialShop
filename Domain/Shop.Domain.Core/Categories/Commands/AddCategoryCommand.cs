using Shop.Core.Domain.Categories.Entities;
using Shop.Core.Domain.Photos.Entities;
using Shop.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;


namespace Shop.Core.Domain.Categories.Commands
{
    public class AddCategoryCommand:ICommand
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public string PhotoUrl { get; set; }
        public int PhotoSize { get; set; }
    }
}
