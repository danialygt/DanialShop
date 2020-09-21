using Shop.Framework.Commands;


namespace Shop.Core.Domain.Orders.Commands
{
    public class SetTransactionCommand : ICommand
    {

        public long OrderId { get; set; }
        public string PaymentId { get; set; }
        
    }


}
