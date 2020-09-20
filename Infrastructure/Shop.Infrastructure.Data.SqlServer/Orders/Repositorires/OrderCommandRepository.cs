using Shop.Core.Domain.Orders.Entities;
using Shop.Core.Domain.Orders.Repositories;

namespace Shop.Infrastructure.Data.SqlServer.Orders.Repositorires
{
    public class OrderCommandRepository : IOrderCommandRepository
    {
        private readonly ShopDbContext _shopDbContext;

        public OrderCommandRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public void Add(Order order)
        {
            _shopDbContext.Orders.Add(order);
            _shopDbContext.SaveChanges();
        }

        public Order Find(long orderId)
        {
            return _shopDbContext.Orders.Find(orderId);
        }

        public void Save()
        {
            _shopDbContext.SaveChanges();
        }
    }
}
