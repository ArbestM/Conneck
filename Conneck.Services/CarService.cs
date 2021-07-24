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
                              CarName = model.CarName,
                              Description = model.Description,
                              Model = model.Model,
                              Brand = model.Brand,
                              Color = model.Color,
                              FBY = model.FBY,
                              VIN = model.VIN,
                              CarType = model.CarType,
                              PlateNumber = model.PlateNumber,
                              StoreID = model.Admin.AdminID,
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
                               .Where(e => e.OwerId == _userId)
                              .Select(
                                    e =>
                                    new CarList
                                    {
                                          CarID = e.CarID,
                                          CarName = e.CarName,
                                          CarType = e.CarType,
                                       //   CategoryID = e.CategoryID,
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
                              CarName = entity.CarName,
                              Description = entity.Description,
                              Brand = entity.Brand,
                              Color = entity.Color,
                              PlateNumber = entity.PlateNumber,
                              VIN = entity.VIN,
                              FBY = entity.FBY,
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

                        entity.CarName = model.CarName;
                        entity.Description = model.Description;
                        entity.Color = model.Color;
                        entity.CarType = model.CarType;
                        entity.PlateNumber = model.PlateNumber;
                        entity.Admin.AdminID = model.AdminID;
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
