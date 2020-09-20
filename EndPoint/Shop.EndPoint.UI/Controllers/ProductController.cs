using Microsoft.AspNetCore.Mvc;
using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Queries;
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

        public IActionResult list()
        {
            var allproducts = _queryDispatcher.Dispatch<List<MasterProduct>>(new GetAllMasterProductQuery());
            if(allproducts != null)
            {
                return View(allproducts);
            }
            return NotFound();
        }

        public IActionResult Detail(int id)
        {

            var product = _queryDispatcher.Dispatch<MasterProduct>(new GetByIdMasterProductQuery() { ProductId = id });
            if (product != null)
            {
                return View(product);
            }
            return NotFound();
        }

        //public IActionResult Buy(int id)
        //{
        //    //inja bayad safhe kharid ya sabad biad!
        //    return NotFound();
        //}

    }
}
