using Microsoft.AspNetCore.Http;
using Shop.Core.Resources.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.EndPoints.WebUI.Areas.Admin.Models.Masters
{
    public class AddMasterViewModel
    {
        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.FirstName)]
        public string FirstName { get; set; }
        
        
        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.LastName)]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Photo)]
        public IFormFile Photo { get; set; }
        
        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Description)]
        public string Description { get; set; }
        
        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.ShortDescription)]
        public string ShortDescription { get; set; }
        
      
        
        
        
    }


}
