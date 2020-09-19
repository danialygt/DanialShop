using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Data.SqlServer.Masters.Repositories
{
    public class MasterCommandRepository : IMasterCommandRepository
    {
        private readonly ShopDbContext _shopDbContext;

        public MasterCommandRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public void Add(Master master)
        {
            _shopDbContext.Masters.Add(master);
            _shopDbContext.SaveChanges();
        }
    }
}
