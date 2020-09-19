using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Queries;
using Shop.Core.Domain.Masters.Repositories;
using Shop.Framework.Queries;
using System.Collections.Generic;

namespace Shop.Core.ApplicationService.Masters.Queries
{
    public class GetAllMasterQueryHandler : IQueryHandler<GetAllMasterQuery, List<Master>>
    {
        private readonly IMasterQueryRepository _masterQueryRepository;

        public GetAllMasterQueryHandler(IMasterQueryRepository masterQueryRepository)
        {
            _masterQueryRepository = masterQueryRepository;
        }

        public List<Master> Handle(GetAllMasterQuery query)
        {
            return _masterQueryRepository.GetAll();
        }
    }


}
