using Shop.Core.Domain.Orders.Commands;
using Shop.Core.Domain.Orders.Entities;
using Shop.Core.Domain.Orders.Repositories;
using Shop.Framework.Commands;
using Shop.Framework.Resources;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.ApplicationService.Orders.Commands
{
    public class SetTransactionCommandHandler : CommandHandler<SetTransactionCommand>
    {
        private readonly IOrderCommandRepository _orderCommandRepository;

        public SetTransactionCommandHandler(IResourceManager resourceManager,
            IOrderCommandRepository orderCommandRepository) : base(resourceManager)
        {
            _orderCommandRepository = orderCommandRepository;
        }

        public override CommandResult Handle(SetTransactionCommand command)
        {
            Order order = _orderCommandRepository.Find(command.OrderId);
            order.PaymentId = command.PaymentId;
            _orderCommandRepository.Save();
            return Ok();


        }
    }

}
