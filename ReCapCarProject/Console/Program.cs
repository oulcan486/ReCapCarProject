using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarDetail();
            //CarTest();
            // BrandTest();
            //ColorTest();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color blue = new Color { Id = 1002, Name = "Yellow" };
            var result = colorManager.GetById(2);

            Console.WriteLine(result.Name);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand mercedes = new Brand { Id = 1004, Name = "Chevrolet" };
            var result = brandManager.GetById(2);
            Console.WriteLine(result.Name);
            Console.WriteLine("Eklendi");
            Console.ReadKey();
        }

        private static void CarDetail()
        {
            CarManager carManagerDetail = new CarManager(new EfCarDal());
            foreach (var c in carManagerDetail.GetCarDetails())
            {
                Console.WriteLine("Markası: {0} ,Adı:{1} , Renk:{2} ,Günlük Ücreti:{3}", c.BrandName, c.CarName, c.ColorName, c.DailyPrice);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car audi = new Car { BrandId = 3, ColorId = 1, DailyPrice = 600, Description = "A2", ModelYear = "2017" };
            carManager.Add(audi);
            /* foreach (var c in carManager.GetCarsByColorId(2))
             {
                 Console.WriteLine("{0}, {1}, {2}, {3}, {4},{5}" , c.Id, c.ColorId, c.BrandId, c.DailyPrice, c.Description,c.ModelYear);
             }*/
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}", c.ColorId, c.BrandId, c.DailyPrice, c.Description, c.ModelYear);
            }
        }
    }
}
