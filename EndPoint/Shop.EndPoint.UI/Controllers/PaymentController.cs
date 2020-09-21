using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shop.Core.Domain.Orders.Commands;
using Shop.Core.Domain.Orders.Entities;
using Shop.Core.Domain.Orders.Queries;
using Shop.Core.Domain.Payments.Entities;
using Shop.Framework.Commands;
using Shop.Framework.Queries;
using Shop.Framework.Resources;
using Shop.Framework.Web;

namespace Shop.EndPoints.WebUI.Controllers
{
    public class PaymentController : BaseController
    {

        private readonly PaymentService _paymentService;
        private readonly IConfiguration _configuration;


        public PaymentController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager
            , PaymentService paymentService, IConfiguration configuration) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
            _paymentService = paymentService;
            _configuration = configuration;
        }

        
        [HttpPost]
        public IActionResult RequestPayment(int orderId)
        {
            var order = _queryDispatcher.Dispatch<Order>(new GetByIdOrderQuery
            {
                OrderId = orderId
            });

            var result = _paymentService.RequestPayment(order.OrderLines.Sum(c => c.Price).ToString(), "09121234567", order.Id.ToString(), $"Description {order.Customer.FirstName} {order.Customer.LastName}");

            if (result.IsCorrect)
            {
                _commandDispatcher.Dispatch(new SetTransactionCommand
                {
                    OrderId = orderId,
                    PaymentId = result.Token
                });
                return Redirect($"{_configuration["PayIr:PaymentUrl"]}{result.Token}");
            }

            return View("PaymentError", result);
        }



        public IActionResult Verify(PaymentResult result)
        {
            if (result.IsCorrect)
            {
                var verifyResult = _paymentService.VerifyPayment(result.Token.ToString());
                if (verifyResult.IsCorrect)
                {
                    _commandDispatcher.Dispatch(new SetPaymentDoneCommand
                    {
                        OrderId = long.Parse(verifyResult.FactorNumber)
                    });
                    return View("PaymentCompelete", verifyResult);                    
                }
            }
            return View("PaymentError", result);
        }

















    }
}
