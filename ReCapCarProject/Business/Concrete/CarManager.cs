﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public Car GetById(int id) {
            return _carDal.Get(c=>c.Id==id);
        }
        public void Add(Car entity)
        {
            if (entity.Description.Length==2 && entity.DailyPrice>0)
            {
                _carDal.Add(entity);
            }
            else
            {
                Console.WriteLine("Eklenemedi");
            }
        }

       public void Update(Car entity) {
            _carDal.Update(entity);
        }
        public void Delete(Car entity) {
            _carDal.Delete(entity);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetail();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }
    }
}
