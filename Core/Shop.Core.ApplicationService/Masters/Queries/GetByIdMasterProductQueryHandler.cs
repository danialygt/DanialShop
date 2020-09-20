using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Queries;
using Shop.Core.Domain.Masters.Repositories;
using Shop.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.ApplicationService.Masters.Queries
{
    public class GetByIdMasterProductQueryHandler : IQueryHandler<GetByIdMasterProductQuery, MasterProduct>
    {
        private IMasterProductQueryRepository _masterProductQueryRepository;
        public GetByIdMasterProductQueryHandler(IMasterProductQueryRepository masterQueryRepository)
        {
            _masterProductQueryRepository = masterQueryRepository;
        }

        public MasterProduct Handle(GetByIdMasterProductQuery query)
        {
            return _masterProductQueryRepository.GetById(query.ProductId);
        }
    }
}
