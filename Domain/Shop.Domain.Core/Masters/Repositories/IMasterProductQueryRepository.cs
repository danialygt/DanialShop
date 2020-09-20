using Shop.Core.Domain.Masters.Dto;
using Shop.Core.Domain.Masters.Entities;
using System.Collections.Generic;

namespace Shop.Core.Domain.Masters.Repositories
{
    public interface IMasterProductQueryRepository
    {
        List<DtoProduct> GetAll();
        DtoProductDetail GetById(long id);
        List<MasterProduct> GetAllByMasterId(long MasterId);

    }
}
