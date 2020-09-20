using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain.Masters.Dto;
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


        public List<DtoMaster> GetAll()
        {
            return _shopDbContext.Masters.AsNoTracking()
                .Include(c=>c.Photo).Include(c => c.MasterProducts)
                .Select(c=> new DtoMaster
                {
                    Id = c.Id,
                    Name = $"{c.FirstName} {c.LastName}",
                    PhotoUrl = c.Photo.Url,
                    ShortDescription = c.ShortDescription,
                    NumberOfProducts = c.MasterProducts.Count
                }).ToList();
        }

        public DtoMasterDetail GetById(long id)
        {
            return _shopDbContext.Masters.AsNoTracking()
                .Include(c => c.Photo).Include(c => c.MasterProducts).ThenInclude(c=>c.Photos)
                .Select(c => new DtoMasterDetail
                {
                    Id = c.Id,
                    Name = $"{c.FirstName} {c.LastName}",
                    PhotoUrl = c.Photo.Url,
                    Description = c.Description,
                    MasterProducts = c.MasterProducts                    
                }).FirstOrDefault(c => c.Id == id);
        }


    }
}
