using Shop.Core.Domain.Categories.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Categories.Repositories
{
    public interface ICategoryCommandRepository
    {
        void Add(Category category);

    }
}
