using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Domain.Masters.Commands;
using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Queries;
using Shop.EndPoints.WebUI.Areas.Admin.Models.Masters;
using Shop.EndPoints.WebUI.FileServices;
using Shop.Framework.Commands;
using Shop.Framework.Queries;
using Shop.Framework.Resources;
using Shop.Framework.Web;



namespace Shop.EndPoints.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MastersController : BaseController
    {
        public MastersController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager) : base(commandDispatcher, queryDispatcher, resourceManager)
                                 
        {
        }

        public IActionResult Index()
        {
            var allMaster = _queryDispatcher.Dispatch<List<Master>>(new GetAllMasterQuery());
            return View(allMaster);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddMasterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var fileUrl = new FileSaver().Save(viewModel.Photo);
                var result = _commandDispatcher.Dispatch(new AddMasterCommand 
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Description = viewModel.Description,
                    ShortDescription = viewModel.ShortDescription,
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
