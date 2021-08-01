using Conneck.Data;
using Conneck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Services
{
      public class CategoryService
      {
            private Guid userId;

            public CategoryService(Guid userId)
            {
                  this.userId = userId;
            }
            private ApplicationDbContext _db = new ApplicationDbContext();

            List<CarCategory> _category = new List<CarCategory>();

            public bool CreateCategory(CreateCategory model)
            {
                  var entity =
                        new CarCategory()
                        {
                              CategoryName = model.CategoryName,
                              Description = model.Description,
                              AdminC = model.AdminC,
                        };

                  using (var ctx = new ApplicationDbContext())
                  {
                        _category.Add(entity);

                        ctx.CarCategories.Add(entity);
                        

                        return ctx.SaveChanges() == 1;
                  }
            }

            public IEnumerable<CatListItem> GetCategories()
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var query =
                              ctx

                              .CarCategories
                              .Select(e =>
                              new CatListItem
                              {
                                    CategoryID = e.CategoryID,
                                    CategoryName = e.CategoryName

                              });

                        return query.ToArray();

                  }
            }


            public bool UpdateCategory(EditCategory model)
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var entity =
                             ctx

                             .CarCategories

                             .Single(e => e.CategoryID== e.CategoryID);

                        entity.CategoryName = model.CategoryName;
                        entity.Description = model.Description;
                        entity.AdminM = model.AdminM;
                        entity.Modified = DateTimeOffset.Now;
                      
                        return ctx.SaveChanges() == 1;
                  }
            }

            public DetailCategory GetCategoryById(int categoryID)
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var entity =
                              ctx

                              .CarCategories

                              .Single(e => e.CategoryID == categoryID);
                        return
                              new DetailCategory
                              {
                                    CategoryID = entity.CategoryID,
                                    CategoryName= entity.CategoryName,
                                    Description = entity.Description,
                                    AdminC = entity.AdminC,
                                    AdminM = entity.AdminM,
                                    CreatedUtc = DateTimeOffset.UtcNow,
                                    ModifiedUtc = DateTimeOffset.UtcNow

                              };
                  }
            }


            public bool DeleteCategoryById(int categoryID)
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var entity =
                              ctx

                              .CarCategories
                              .Single(e => e.CategoryID == categoryID);

                        ctx.CarCategories.Remove(entity);

                        return ctx.SaveChanges() == 1;
                  }
            }

          /*  public bool DeleteCategoryByName(string categoryName)
            {
                  foreach(var item in _category)
                  {
                        if (item.CategoryName.Equals(categoryName))
                        {
                              _category.Remove(item);
                           
                              _db.CarCategories.Remove(item);

                              return _db.SaveChanges() == 1;
                        }
                  }
                  return false;
            }
*/
      }
}
