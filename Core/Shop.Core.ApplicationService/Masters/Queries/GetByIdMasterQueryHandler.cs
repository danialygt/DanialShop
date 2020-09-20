using Shop.Core.Domain.Masters.Dto;
using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Queries;
using Shop.Core.Domain.Masters.Repositories;
using Shop.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.ApplicationService.Masters.Queries
{
    public class GetByIdMasterQueryHandler : IQueryHandler<GetByIdMasterQuery, DtoMasterDetail>
    {

        private readonly IMasterQueryRepository _masterQueryRepository;

        public GetByIdMasterQueryHandler(IMasterQueryRepository masterQueryRepository)
        {
            _masterQueryRepository = masterQueryRepository;
        }


        public DtoMasterDetail Handle(GetByIdMasterQuery query)
        {
            return _masterQueryRepository.GetById(query.MasterId);
        }
    }
}
