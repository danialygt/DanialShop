using Shop.Core.Domain.Photos.Entities;
using Shop.Framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.Core.Domain.Masters.Entities
{
    public class Master:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime MembershipDate { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }




        public long PhotoId { get; set; }
        public Photo Photo { get; set; }


        public List<MasterProduct> MasterProducts { get; set; }
        


    }



}
