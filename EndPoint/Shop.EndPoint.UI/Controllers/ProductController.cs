using Microsoft.AspNetCore.Mvc;
using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Queries;
using Shop.Core.Domain.Masters.Repositories;
using Shop.Framework.Commands;
using Shop.Framework.Queries;
using Shop.Framework.Resources;
using Shop.Framework.Web;
using System.Collections.Generic;

namespace Shop.EndPoints.WebUI.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
        }

        //public IActionResult List()
        //{

        //    var allProducts = _queryDispatcher.Dispatch<List<MasterProduct>>(new GetAllMasterProductQuery());
        //    return View(allProducts);
        //}

        //public IActionResult Detail(int id)
        //{

        //    var product = _queryDispatcher.Dispatch<MasterProduct>(new GetByIdMasterProductQuery() { productId = id });
        //    return View(product);
        //}

        //public IActionResult Buy(int id)
        //{
        //    //inja bayad safhe kharid ya sabad biad!
        //    return NotFound();
        //}

    }
}
