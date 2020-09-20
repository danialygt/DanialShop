using Microsoft.AspNetCore.Mvc;
using Shop.Core.Domain.Masters.Dto;
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

        public IActionResult List()
        {
            var allproducts = _queryDispatcher.Dispatch<List<DtoProduct>>(new GetAllMasterProductQuery());
            if(allproducts != null)
            {
                return View(allproducts);
            }
            return NotFound();
        }

        public IActionResult Detail(int id)
        {

            var product = _queryDispatcher.Dispatch<DtoProductDetail>(new GetByIdMasterProductQuery() { ProductId = id });
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
