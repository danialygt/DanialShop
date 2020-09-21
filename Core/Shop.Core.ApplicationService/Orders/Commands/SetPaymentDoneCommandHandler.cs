using Shop.Core.Domain.Orders.Commands;
using Shop.Core.Domain.Orders.Entities;
using Shop.Core.Domain.Orders.Repositories;
using Shop.Framework.Commands;
using Shop.Framework.Resources;
using System;

namespace Shop.Core.ApplicationService.Orders.Commands
{
    public class SetPaymentDoneCommandHandler : CommandHandler<SetPaymentDoneCommand>
    {
        private readonly IOrderCommandRepository _orderCommandRepository;

        public SetPaymentDoneCommandHandler(IResourceManager resourceManager,
            IOrderCommandRepository orderCommandRepository) : base(resourceManager)
        {
            _orderCommandRepository = orderCommandRepository;
        }

        public override CommandResult Handle(SetPaymentDoneCommand command)
        {
            Order order = _orderCommandRepository.Find(command.OrderId);
            order.PaymentDate = DateTime.Now;
            _orderCommandRepository.Save();
            return Ok();


        }
    }

}
