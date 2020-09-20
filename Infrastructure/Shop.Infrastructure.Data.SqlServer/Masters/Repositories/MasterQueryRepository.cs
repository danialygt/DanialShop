using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data.SqlServer.Masters.Repositories
{
    public class MasterQueryRepository : IMasterQueryRepository
    {
        private readonly ShopDbContext _shopDbContext;

        public MasterQueryRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }



        public List<Master> GetAll()
        {
            return _shopDbContext.Masters.AsNoTracking()
                .Include(c=>c.Photo).Include(c => c.MasterProducts).ToList();
        }

        public Master GetById(long id)
        {
            return _shopDbContext.Masters.AsNoTracking()
                .Include(c => c.Photo).Include(c => c.MasterProducts).ThenInclude(c=>c.Photos)
                .FirstOrDefault(c => c.Id == id);
        }


  
    }
}
