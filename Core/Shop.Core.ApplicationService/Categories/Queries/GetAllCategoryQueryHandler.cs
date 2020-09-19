using Shop.Core.Domain.Categories.Entities;
using Shop.Core.Domain.Categories.Queries;
using Shop.Core.Domain.Categories.Repositories;
using Shop.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.ApplicationService.Categories.Queries
{

    public class GetAllCategoryQueryHandler : IQueryHandler<GetAllCategoryQuery, List<Category>>
    {

        private ICategoryQueryRepository _categoryQueryRepository;
        public GetAllCategoryQueryHandler(ICategoryQueryRepository categoryQueryRepository)
        {
            _categoryQueryRepository = categoryQueryRepository;
        }

        public List<Category> Handle(GetAllCategoryQuery query)
        {
            return _categoryQueryRepository.GetAll();
        }
    }

}
