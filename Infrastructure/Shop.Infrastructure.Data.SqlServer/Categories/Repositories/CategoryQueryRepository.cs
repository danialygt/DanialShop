using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain.Categories.Entities;
using Shop.Core.Domain.Categories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Infrastructure.Data.SqlServer.Categories.Repositories
{
    public class CategoryQueryRepository : ICategoryQueryRepository
    {

        private readonly ShopDbContext _shopDbContext;

        public CategoryQueryRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public List<Category> GetAll()
        {
            return _shopDbContext.Categories
                .Include(c => c.Photo).Include(c => c.Children).ThenInclude(c => c.Photo)
                .ToList();
        }

        public List<Category> GetParentCategories()
        {
            return _shopDbContext.Categories
                .Where(c => !c.ParentId.HasValue)
                .Include(c => c.Photo).Include(c => c.Children).ThenInclude(c => c.Photo)
                .ToList();
        }
    }
}
