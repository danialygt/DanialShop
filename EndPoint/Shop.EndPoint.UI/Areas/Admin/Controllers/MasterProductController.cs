using Microsoft.AspNetCore.Mvc;
using Shop.Core.Domain.Categories.Entities;
using Shop.Core.Domain.Categories.Queries;
using Shop.Core.Domain.Masters.Commands;
using Shop.Core.Domain.Masters.Dto;
using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Queries;
using Shop.Core.Domain.Photos.Entities;
using Shop.EndPoints.WebUI.Areas.Admin.Models.Masters;
using Shop.EndPoints.WebUI.FileServices;
using Shop.Framework.Commands;
using Shop.Framework.Queries;
using Shop.Framework.Resources;
using Shop.Framework.Web;
using System.Collections.Generic;

namespace Shop.EndPoints.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasterProductController : BaseController
    {
        public MasterProductController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
        }



        public IActionResult Index()
        {
            var allProduct = _queryDispatcher.Dispatch<List<DtoProduct>>(new GetAllMasterProductQuery());
            return View(allProduct);
        }

        public IActionResult AddProduct()
        {
            var viewModel = new AddMasterProductViewModel
            {
                Categories = _queryDispatcher.Dispatch<List<Category>>(new GetAllCategoryQuery()),
                Masters = _queryDispatcher.Dispatch<List<DtoMaster>>(new GetAllMasterQuery())
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddProduct(AddMasterProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var filesUrl = new List<string>();
                foreach (var item in viewModel.Photos)
                {
                    filesUrl.Add(new FileSaver().Save(item));
                }


                var result = _commandDispatcher.Dispatch(new AddMasterProductCommand
                {
                    Name = viewModel.Name,
                    Price = viewModel.Price,
                    Discount = viewModel.Discount,
                    Description = viewModel.Description,
                    ShortDescription = viewModel.ShortDescription,
                    MasterId = viewModel.MasterId,
                    CategoryId = viewModel.CategoryId,
                    Photos = filesUrl

                });
                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", result.Message);
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item);
                }
            }
            return View(viewModel);
        }

    }
}
