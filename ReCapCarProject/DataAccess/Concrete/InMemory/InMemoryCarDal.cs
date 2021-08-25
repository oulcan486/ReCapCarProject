using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
  public  class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{ Id=1,BrandId=1,ColorId=1,DailyPrice=150,Description="Mazda",ModelYear="2000"},
                new Car{ Id=2,BrandId=1,ColorId=2,DailyPrice=350,Description="Opel",ModelYear="2005"},
                new Car{ Id=3,BrandId=2,ColorId=1,DailyPrice=250,Description="Şahin",ModelYear="2010"},
                new Car{ Id=4,BrandId=2,ColorId=2,DailyPrice=550,Description="BMV",ModelYear="2017"}
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            var deleteCar = _car.SingleOrDefault(c=>c.Id==car.Id);
            _car.Remove(deleteCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _car.Where(c=>c.Id==id).ToList();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var deleteCar = _car.SingleOrDefault(c => c.Id == car.Id);
            deleteCar.ColorId = car.ColorId;
            deleteCar.BrandId = car.BrandId;
            deleteCar.DailyPrice = car.DailyPrice;
            deleteCar.Description = car.Description;
            deleteCar.ModelYear = car.ModelYear;
        }
    }
}
