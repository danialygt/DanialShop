using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Core.Domain.Categories.Entities;
using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Resources.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Shop.EndPoints.WebUI.Areas.Admin.Models.Masters
{
    public class AddMasterProductViewModel
    {
        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.ProductName)]
        public string Name { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Price)]
        public long Price { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Discount)]
        public long Discount { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Description)]
        public string Description { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.ShortDescription)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Master)]
        public long MasterId { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.CategoryName)]
        public long CategoryId { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Photos)]
        public List<IFormFile> Photos { get; set; }


        public List<Master> Masters { get; set; }
        public List<Category> Categories { get; set; }


        public List<SelectListItem> GetCategoriesListItems()
        {
            var result =
            Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            return result;
        }
        public List<SelectListItem> GetMastersListItems()
        {
            var result =
            Masters.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.FirstName} {c.LastName}"
            }).ToList();
            return result;
        }



    }


}
