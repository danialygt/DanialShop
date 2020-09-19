using Shop.Core.Domain.Categories.Entities;
using Shop.Core.Domain.Categories.Queries;
using Shop.Core.Domain.Categories.Repositories;
using Shop.Framework.Queries;
using System.Collections.Generic;

namespace Shop.Core.ApplicationService.Categories.Queries
{
    public class GetParentCategoriesQueryHandler : IQueryHandler<GetParentCategoriesQuery, List<Category>>
    {

        private ICategoryQueryRepository _categoryQueryRepository;
        public GetParentCategoriesQueryHandler(ICategoryQueryRepository categoryQueryRepository)
        {
            _categoryQueryRepository = categoryQueryRepository;
        }

        public List<Category> Handle(GetParentCategoriesQuery query)
        {
            return _categoryQueryRepository.GetParentCategories();

        }
    }

}
