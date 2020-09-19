using Shop.Core.Domain.Masters.Entities;
using System.Collections.Generic;

namespace Shop.Core.Domain.Masters.Repositories
{
    public interface IMasterProductQueryRepository
    {
        List<MasterProduct> GetAll();
        MasterProduct GetById(long id);
        List<MasterProduct> GetAllByMasterId(long MasterId);

    }
}
