using Conneck.Data;
using Conneck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Services
{
      public class StoreService
      {


            private Guid userId;

            public StoreService(Guid userId)
            {
                  this.userId = userId;
            }

            public bool CreateStore(CreateStore model)
            {
                  var entity =
                        new Store
                        {
                              StoreName = model.StoreName,
                              Description = model.Description,
                              Email = model.Email,
                              Address = model.Address,
                              Unit = model.Unit,
                              City = model.City,
                              State = model.State,
                              Zip = model.Zip,
                              AdminID = model.AdminID,
                              CreatedUtc = DateTimeOffset.UtcNow
                        };
                  using (var ctx = new ApplicationDbContext())
                  {

                        ctx.Stores.Add(entity);

                        return ctx.SaveChanges() == 1;
                  }
            }

            public StoreDetail GetStoreByID(int storeID)
            {
                  using(var ctx = new ApplicationDbContext())
                  {
                        var entity =
                              ctx
                              .Stores
                              .Single(a => a.StoreID == storeID);

                        return new StoreDetail
                        {
                              StoreID = entity.StoreID,
                              StoreName = entity.StoreName,
                              Email = entity.Email,
                              Description = entity.Description,
                              Address = entity.Address,
                              Unit = entity.Unit,
                              City = entity.City,
                              State = entity.State,
                              Zip = entity.Zip,
                              AdminID = entity.AdminID,
         
                             
                        };
                  }
            }

            public IEnumerable<StoreList> GetAllStores()
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var query =
                              ctx
                              .Stores                         
                              .Select(s =>
                              new StoreList
                              {
                                   StoreID = s.StoreID,
                                   Name = s.StoreName,
                              });

                        return query.ToArray();

                  }
            }


            public bool UpdateStore(EditStore model)
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var entity =
                             ctx
                            .Stores
                             .Single(s => s.StoreID == model.StoreID);
                        
                        entity.StoreName = model.StoreName;
                        entity.Description = model.Description;
                        entity.Email = model.Email;
                        entity.Address = model.Address;
                        entity.Unit = model.Unit;
                        entity.City = model.City;
                        entity.State = model.State;
                        entity.Admin.AdminID = model.AdminID;
                        entity.Zip = model.Zip;
                        entity.Modified = DateTimeOffset.UtcNow;

                        return ctx.SaveChanges() == 1;
                  }
            }

            public bool DeleteStoreByID(int storeID)
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var entity =
                              ctx

                              .Stores
                              .Single(s => s.StoreID == storeID);

                        ctx.Stores.Remove(entity);

                        return ctx.SaveChanges() == 1;
                  }
            }

      } 
}

