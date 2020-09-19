using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Data.SqlServer.Masters.Repositories
{
    public class MasterProductCommandRepository : IMasterProductCommandRepository
    {
        private readonly ShopDbContext _shopDbContext;

        public MasterProductCommandRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public void Add(MasterProduct masterProduct)
        {
            _shopDbContext.MasterProducts.Add(masterProduct);
            _shopDbContext.SaveChanges();
        }
    }
}
