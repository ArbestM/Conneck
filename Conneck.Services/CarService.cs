using Conneck.Data;
using Conneck.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                              OwerId = _userId,
                              CarType = model.CarType,
                              CarName = model.CarName,
                              Description = model.Description,
                              Model = model.Model,
                              Brand = model.Brand,
                              Color = model.Color,
                              VIN = model.VIN,
                              FBY = model.FBY,
                              PlateNumber = model.PlateNumber
                        };

                  using (var ctx = new ApplicationDbContext())
                  {
                        ctx.Cars.Add(entity);

                        return ctx.SaveChanges() == 1;
                  }
            }

            public IEnumerable<CarListItem> GetCars()
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var query =
                              ctx

                              .Cars
                              .Where(e => e.OwerId == _userId)
                              .Select(
                                    e =>
                                    new CarListItem
                                    {
                                          CarID = e.CarID,
                                          CarName = e.CarName,
                                          
                                          CarType = e.CarType,
                                    });

                        return query.ToArray();
                  }


            }

            public CarDetail GetCarById(int id)
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var entity =
                              ctx
                              .Cars
                              .Single(e => e.CarID == id);
                        return
                              new CarDetail
                              {
                                    CarID = entity.CarID,
                                    CarType = entity.CarType,
                                    CarName = entity.CarName,
                                    Description = entity.Description,
                                    //Model = model.Model,
                                    Brand = entity.Brand,
                                    Color = entity.Color,
                                    VIN = entity.VIN,
                                    FBY = entity.FBY,
                                    PlateNumber = entity.PlateNumber,
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
                              .Single(E => E.CarID == model.CarID);
                        entity.CarID = model.CarID;
                        entity.Description = model.Description;
                        entity.CarName = model.CarName;
                        entity.Brand = model.Brand;
                        entity.Color = model.Color;
                        entity.PlateNumber = model.PlateNumber;
                        entity.Modified = DateTimeOffset.UtcNow;

                        return ctx.SaveChanges() == 1;

                  }
            }

            public bool DeleteCarId(int id)
            {
                  using(var ctx = new ApplicationDbContext())
                  {
                        var entity =
                              ctx
                              .Cars
                              .Single(e => e.CarID == id);
                        ctx.Cars.Remove(entity);

                        return ctx.SaveChanges() == 1;
                  }
            }
      }
}
