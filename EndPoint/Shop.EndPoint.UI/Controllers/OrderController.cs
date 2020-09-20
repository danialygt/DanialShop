using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Domain.Carts;
using Shop.Core.Domain.Orders.Commands;
using Shop.Core.Domain.Orders.Entities;
using Shop.Core.Domain.Orders.Queries;
using Shop.EndPoints.WebUI.Models.Order;
using Shop.Framework.Commands;
using Shop.Framework.Queries;
using Shop.Framework.Resources;
using Shop.Framework.Web;



namespace Shop.EndPoints.WebUI.Controllers
{
    public class OrderController : BaseController
    {

        private Cart _cart;

        public OrderController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager, Cart cart) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
            _cart = cart;
        }


        public ViewResult Checkout()
        {
            return View(new CheckoutViewModel());
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new CheckOutCommand
                {
                    Address = model.Address,
                    Cart = _cart,
                    City = model.City,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    NationalCode = model.NationalCode,
                    Phone = model.Phone,
                    Provience = model.Provience
                };
                var result = _commandDispatcher.Dispatch(command);
                if (result.IsSuccess)
                {
                    _cart.Clear();
                    return RedirectToAction(nameof(Completed), new { Id = command.OrderId });
                }
                foreach (string item in result.Errors)
                {
                    ModelState.AddModelError("", item);
                }
            }

            return View(model);
        }



        public IActionResult Completed(long id)
        {
            var order = _queryDispatcher.Dispatch<Order>(new GetByIdOrderQuery
            {
                OrderId = id
            });
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

    }
}
