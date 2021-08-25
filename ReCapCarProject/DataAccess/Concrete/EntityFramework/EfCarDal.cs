using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : IEntityRepositoryBase<Car, ReCapCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (ReCapCarContext context=new ReCapCarContext())
            {
                var result = from p in context.Car
                             join c in context.Color on p.ColorId equals c.Id
                             join b in context.Brand on p.BrandId equals b.Id
                             select new CarDetailDto { CarName=p.Description,BrandName=b.Name
                             ,ColorName=c.Name,DailyPrice=p.DailyPrice};
                return result.ToList();

            }
        }
    }
}
