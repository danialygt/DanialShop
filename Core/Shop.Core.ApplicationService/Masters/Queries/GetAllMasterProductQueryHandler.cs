using Shop.Core.Domain.Masters.Dto;
using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Queries;
using Shop.Core.Domain.Masters.Repositories;
using Shop.Framework.Queries;
using System.Collections.Generic;

namespace Shop.Core.ApplicationService.Masters.Queries
{
    public class GetAllMasterProductQueryHandler : IQueryHandler<GetAllMasterProductQuery, List<DtoProduct>>
    {

        private IMasterProductQueryRepository _masterQueryRepository;
        public GetAllMasterProductQueryHandler(IMasterProductQueryRepository masterQueryRepository)
        {
            _masterQueryRepository = masterQueryRepository;
        }

        public List<DtoProduct> Handle(GetAllMasterProductQuery query)
        {
            return _masterQueryRepository.GetAll();
        }
    }
}
