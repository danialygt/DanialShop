using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Domain.Carts;
using Shop.Core.Domain.Masters.Dto;
using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Queries;
using Shop.EndPoints.WebUI.Models.Carts;
using Shop.Framework.Commands;
using Shop.Framework.Queries;
using Shop.Framework.Resources;
using Shop.Framework.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.EndPoints.WebUI.Controllers
{
    public class CartController : BaseController
    {

        private Cart _cart;

        public CartController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager, Cart cart) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
            _cart = cart;

        }


        public ViewResult Index (string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = _cart,
                ReturnUrl = returnUrl
            });
        }
       
        [HttpPost]
        public RedirectToActionResult AddToCart (int productId, string retutnUrl)
        {
            var product = _queryDispatcher.Dispatch<DtoProduct>(new GetByIdMasterProductQuery() { ProductId = productId});
            if (product != null)
            {
                _cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { retutnUrl });
        }
        

    }
}
