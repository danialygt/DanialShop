using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data.SqlServer.Masters.Repositories
{
    public class MasterProductQueryRepository : IMasterProductQueryRepository
    {
        private readonly ShopDbContext _shopDbContext;

        public MasterProductQueryRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public MasterProduct GetById(long id)
        {
            // benazar sarbar ziadi dashte bashe!!! chon kole rabete haro load mikone bad select mikone!
            return _shopDbContext.MasterProducts.AsNoTracking()
                .Include(c => c.Master).Include(c => c.Photos).Include(c => c.Category)
                .FirstOrDefault(c => c.Id == id);
        }

        public List<MasterProduct> GetAll()
        {
            return _shopDbContext.MasterProducts.AsNoTracking()
                .Include(c => c.Master).Include(c => c.Photos).Include(c => c.Category)
                .ToList();
        }

        public List<MasterProduct> GetAllByMasterId(long MasterId)
        {
            return _shopDbContext.MasterProducts.AsNoTracking().Where(c => c.MasterId == MasterId)
                .Include(c => c.Master).Include(c => c.Photos).Include(c => c.Category)
                .ToList();
        }

       
    }
}
