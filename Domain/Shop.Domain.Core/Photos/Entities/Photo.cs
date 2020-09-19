using Shop.Framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.Core.Domain.Photos.Entities
{
    public class Photo : BaseEntity
    {
        public string Url { get; set; }

    }
}
