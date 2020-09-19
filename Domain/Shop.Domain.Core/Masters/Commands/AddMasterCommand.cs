using Shop.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Masters.Commands
{
    public class AddMasterCommand:ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string PhotoUrl { get; set; }
        public int PhotoSize { get; set; }
    }
}
