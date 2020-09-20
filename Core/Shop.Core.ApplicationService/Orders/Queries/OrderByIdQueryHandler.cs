using Shop.Core.Domain.Orders.Entities;
using Shop.Core.Domain.Orders.Queries;
using Shop.Core.Domain.Orders.Repositories;
using Shop.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.ApplicationService.Orders.Queries
{
    public class OrderByIdQueryHandler : IQueryHandler<GetByIdOrderQuery, Order>
    {
        private readonly IOrderQueryRepository orderQueryRepository;

        public OrderByIdQueryHandler(IOrderQueryRepository orderQueryRepository)
        {
            this.orderQueryRepository = orderQueryRepository;
        }
        public Order Handle(GetByIdOrderQuery query)
        {
            return orderQueryRepository.Select(query);
        }
    }
}
