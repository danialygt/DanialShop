using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain.Masters.Dto;
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

        public DtoProductDetail GetById(long id)
        {
            // benazar sarbar ziadi dashte bashe!!! chon kole rabete haro load mikone bad select mikone!
            return _shopDbContext.MasterProducts.AsNoTracking()
                .Include(c => c.Master).Include(c => c.Photos).Include(c => c.Category)
                .Select(c => new DtoProductDetail
                {
                    Id = c.Id,
                    Name = c.Name,
                    CategoryName = c.Category.Name,
                    Price = c.Price,
                    Discount = c.Discount,
                    Description = c.Description,
                    MasterName = $"{c.Master.FirstName} {c.Master.LastName}",
                    MasterId = c.MasterId,
                    PhotosUrl = c.Photos.Select(c => c.Url).ToList()
                })
                .FirstOrDefault(c => c.Id == id);
        }

        public List<DtoProduct> GetAll()
        {
            return _shopDbContext.MasterProducts.AsNoTracking()
                .Include(c => c.Master).Include(c => c.Photos).Include(c => c.Category)
                .Select(c => new DtoProduct
                {
                    Id = c.Id,
                    Name = c.Name,
                    ShortDescription = c.ShortDescription,
                    MasterId = c.MasterId,
                    Price = c.Price,
                    Discount = c.Discount,
                    CategoryName = c.Category.Name,
                    MasterName = $"{c.Master.FirstName} {c.Master.LastName}",
                    PhotoUrl = c.Photos.FirstOrDefault().Url
                })
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
