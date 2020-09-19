using Microsoft.AspNetCore.Mvc;
using Shop.Core.Domain.Categories.Commands;
using Shop.Core.Domain.Categories.Entities;
using Shop.Core.Domain.Categories.Queries;
using Shop.EndPoints.WebUI.Areas.Admin.Models.Categories;
using Shop.EndPoints.WebUI.FileServices;
using Shop.Framework.Commands;
using Shop.Framework.Queries;
using Shop.Framework.Resources;
using Shop.Framework.Web;
using System.Collections.Generic;


namespace Shop.EndPoints.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : BaseController
    {
        public CategoriesController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
        }

        public IActionResult Index()
        {
            var allCategory = _queryDispatcher.Dispatch<List<Category>>(new GetParentCategoriesQuery());
            return View(allCategory);
        }

        public IActionResult AddCategory()
        {
            var viewModel = new AddCategoryViewModel
            {
                Categories = _queryDispatcher.Dispatch<List<Category>>(new GetAllCategoryQuery())
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var fileUrl = new FileSaver().Save(viewModel.Photo);
                var result = _commandDispatcher.Dispatch(new AddCategoryCommand
                {
                    Name = viewModel.Name,
                    ParentId = viewModel.ParentId,
                    PhotoUrl = fileUrl
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
