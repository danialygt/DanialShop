using Shop.Framework.Commands;


namespace Shop.Core.Domain.Orders.Commands
{
    public class SetPaymentDoneCommand : ICommand
    {
        public long OrderId { get; set; }
        
    }


}
