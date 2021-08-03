using Conneck.Data;
using Conneck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Services
{
      public class AdminService
      {
            

            private readonly Guid _userId;

            public AdminService(Guid userId)
            {
                  _userId = userId;
            }

            public bool CreateAdmin(CreateAdmin model)
            {
                  var entity =
                        new Admin ()
                        {                            
                              FirstName = model.FirstName,
                              LastName = model.LastName,
                              Phone = model.Phone,                            
                              Email = model.Email,
                              Address = model.Address,
                              City = model.City,
                              Zip = model.Zip,
                              State = model.State,
                              CreatedUtc = DateTimeOffset.Now                           
                        };
                
                  using (var ctx = new ApplicationDbContext())
                  {
                        ctx.Admins.Add(entity);

                        return ctx.SaveChanges() == 1;
                  }
            }


            public IEnumerable<AdminList> GetAdmins()
            {
                  // This method will allow us to see all the notes that belongs to a specific user.
                  using (var ctx = new ApplicationDbContext())
                  {
                        var query =
                              ctx
                              .Admins
                             //.Where(e => e.OwnerId == _userId)
                              .Select(
                                    e =>
                                    new AdminList
                                    {
                                          AdminID = e.AdminID,
                                          FirstName = e.FirstName                                                                               
                                   }
                                    );
                        return query.ToArray();
                  }
            }


            public DetailAdmin GetAdminById(int adminID)
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var entity =
                              ctx
                              .Admins
                              .Single(e => e.AdminID == adminID);
                        return
                              new DetailAdmin
                              {
                                   AdminID = entity.AdminID,
                                    FirstName = entity.FirstName,
                                    LastName = entity.LastName,                                  
                                    Phone = entity.Phone,
                                    Email = entity.Email,
                                    Address = entity.Address,
                                    City = entity.City,
                                    Zip= entity.Zip,
                                    State = entity.State,                                   
                                    CreatedUtc =entity.CreatedUtc,
                                    ModifiedUtc = DateTimeOffset.UtcNow

                              };
                  }
            }

          
            public bool UpdateAdmin(EditAdmin model)
            {
                  // this method will update a note in the db
                  using (var ctx = new ApplicationDbContext())
                  {
                        var entity =
                              ctx
                              .Admins
                              .Single(e => e.AdminID == e.AdminID);
                        entity.FirstName = model.FirstName;
                        entity.LastName = model.LastName;
                        entity.Phone = model.Phone;
                        entity.Email = model.Email;
                        entity.Address = model.Address;
                        entity.City = model.City;
                        entity.Zip = model.Zip;
                        entity.State = model.State;
                        entity.ModifiedUtc = DateTimeOffset.Now;

                        return ctx.SaveChanges() == 1;
                  }
            }


            public bool DeleteNote(int adminID)
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var entity =
                              ctx
                              .Admins
                              .Single(e => e.AdminID == adminID);

                        ctx.Admins.Remove(entity);

                        return ctx.SaveChanges() == 1;
                  }
            }
      }

      
}
