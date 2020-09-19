using Shop.Core.Domain.Categories.Entities;
using Shop.Core.Domain.Categories.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Data.SqlServer.Categories.Repositories
{
    public class CategoryCommandRepository : ICategoryCommandRepository
    {

        private readonly ShopDbContext _shopDbContext;

        public CategoryCommandRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public void Add(Category category)
        {
            _shopDbContext.Categories.Add(category);
            _shopDbContext.SaveChanges();
        }
    }
}
