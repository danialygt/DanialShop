using Shop.Core.Domain.Masters.Dto;
using Shop.Core.Domain.Masters.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Masters.Repositories
{
    public interface IMasterQueryRepository
    {
        List<DtoMaster> GetAll();

        DtoMasterDetail GetById(long id);

    }
}
