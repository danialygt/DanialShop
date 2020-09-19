using Shop.Core.Domain.Categories.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Categories.Repositories
{
    public interface ICategoryQueryRepository
    {
        List<Category> GetAll();
        List<Category> GetParentCategories();

    }
}
