using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain.Orders.Entities;
using Shop.Core.Domain.Orders.Queries;
using Shop.Core.Domain.Orders.Repositories;
using System.Linq;

namespace Shop.Infrastructure.Data.SqlServer.Orders.Repositorires
{
    public class OrderQueryRepository : IOrderQueryRepository
    {
        private readonly ShopDbContext _shopDbContext;

        public OrderQueryRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public Order Select(GetByIdOrderQuery query)
        {
            return _shopDbContext.Orders.
                Where(c => c.Id == query.OrderId).
                Include(c => c.OrderLines).
                ThenInclude(c => c.MasterProduct).
                Include(c => c.Customer).FirstOrDefault();
        }
    }
}
