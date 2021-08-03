using Conneck.Data;
using Conneck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Conneck.Data.Car;

namespace Conneck.Services
{

      public class CarService
      {
            private readonly Guid _userId;

            public CarService(Guid userId)
            {
                  _userId = userId;
            }


            public bool CreateCar(CarCreate model)
            {
                  var entity =

                        new Car()
                        {
                              Make = model.Make,
                              CarM = model.CarM,
                              Color = model.Color,
                              VIN = model.VIN,
                              CarType = model.CarType,
                              LicensePlate = model.LicensePlate,
                              Year = model.Year,
                              CategoryID = model.CategoryID,
                              StoreID = model.StoreID,
                              Admin = model.AdminID,
                              Mileage = model.Mileage,
                              Rate = model.Rate
                        };

                  using (var ctx = new ApplicationDbContext())
                  {
                        ctx.Cars.Add(entity);


                        return ctx.SaveChanges() == 1;
                  }
            }


            public IEnumerable<CarList> GetCars()
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var query =
                              ctx

                              .Cars
                            //   .Where(e => e.OwerId == _userId)
                              .Select(
                                    e =>
                                    new CarList
                                    {
                                          CarID = e.CarID,
                                          Make = e.Make,
                                          CarType = e.CarType,
                                            CategoryID = e.CategoryID,
                                          Store = e.Store.StoreID,

                                    });

                        return query.ToArray();
                  }
            }

            public CarDetail GetCarByID(int input)
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var entity =
                              ctx
                              .Cars
                              .Single(e => e.CarID == e.CarID && e.CarID == input);
                        return new CarDetail
                        {
                              CarID = entity.CarID,
                              Make = entity.Make,
                              CarM = entity.CarM,
                              Color = entity.Color,
                              VIN = entity.VIN,
                              LincesePlate = entity.LicensePlate,
                              Year = entity.Year,
                              CategoryID = entity.CarCategory.CategoryID,
                              AdminID = entity.Store.AdminID,
                              CreatedUtc = entity.CreatedUtc,
                              ModifiedUtc = entity.Modified

                        };

                  }
            }

            public bool UpdateCar(CarEdit model)
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var entity =
                              ctx

                              .Cars
                              .Single(e => e.CarID == model.CarID);

                        entity.Make = model.Make;
                        entity.CarM = model.CarM;
                        entity.Color = model.Color;
                        entity.CarType = model.CarType;
                        entity.LicensePlate = model.LicensePlate;
                        entity.Admin = model.AdminID;
                        entity.Modified = DateTimeOffset.UtcNow;

                        return ctx.SaveChanges() == 1;

                  }
            }

            public bool DeleteCarByCardID(int carID)
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var entity =
                              ctx
                              .Cars
                              .Single(e => e.CarID == carID);

                        ctx.Cars.Remove(entity);

                        return ctx.SaveChanges() == 1;
                  }
            }
      }


}
