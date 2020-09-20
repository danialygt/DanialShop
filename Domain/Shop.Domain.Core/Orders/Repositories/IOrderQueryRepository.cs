using Shop.Core.Domain.Orders.Entities;
using Shop.Core.Domain.Orders.Queries;

namespace Shop.Core.Domain.Orders.Repositories
{
    public interface IOrderQueryRepository
    {
        Order Select(GetByIdOrderQuery query);
    }


}
