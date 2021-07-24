using Conneck.Data;
using Conneck.Models;
using Conneck.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conneck.WebMVC.Controllers
{
      public class CategoryController : Controller
      {
            private ApplicationDbContext _db = new ApplicationDbContext();

            public List<CarCategory> _ListOfCategory = new List<CarCategory>();

            // GET: Category
            [Authorize]
            public ActionResult Index()
            {
                  var userId = Guid.Parse(User.Identity.GetUserId());
                  var service = new CategoryService(userId);
                  var model = service.GetCategories();


                  return View(model);

            }

            public ActionResult Create()
            {
                  return View();
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(CreateCategory model)
            {

                  if (!ModelState.IsValid)
                  {
                        return View(model);
                  }

                  foreach(var category in _ListOfCategory)
                  {
                        if (category.CategoryName.Contains(model.CategoryName))
                        {
                              ModelState.AddModelError("", "There is already a category with this name");
                              return View(model);
                        }
                  }
                  var service = CreateCategoryService();

                  if (service.CreateCategory(model))
                  {
                        TempData["SaveResult"] = "Car Category  was created.";
                        return RedirectToAction("Index");
                  }

                  ModelState.AddModelError("", "Car Category could not be createb");
                  return View(model);
            }

            public ActionResult Details(int inputID)
            {
                  var service = CreateCategoryService();
                  var model = service.GetCategoryById(inputID);

                  return View(model);
            }

            public ActionResult Edit(int InputID)
            {
                  var service = CreateCategoryService();

                  var OldModel = service.GetCategoryById(InputID);

                  var UpdadeModel = new EditCategory();

                  if (OldModel != null)
                  {
                        UpdadeModel.CategoryName = OldModel.CategoryName;
                          UpdadeModel.Description = OldModel.Description;
                  }

                  return View(UpdadeModel);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int inputID, EditCategory model)
            {
                  if (!ModelState.IsValid)
                  {
                        return View(model);
                  }

                  if(model.CategoryID != inputID)
                  {
                        ModelState.AddModelError("", "Input Id does not macth");
                  }

                  var updateModel = CreateCategoryService();

                  if (updateModel.UpdateCategory(model))
                  {
                        TempData["SaveResult"] = ".Category Content updated"; 
                        return RedirectToAction("Index");
                  }

                  ModelState.AddModelError("", "Category Content could not be updated");

                  return View(model);
            }

            public ActionResult Delete(int inputID)
            {
                  var service = CreateCategoryService();
                  var model = service.DeleteCategoryById(inputID);

                  return View(model);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult DeletePost(int inputID)
            {
                  var service = CreateCategoryService();

                  service.DeleteCategoryById(inputID);
                  TempData["SaveResult"] = "Item was Deleted.";
                  return RedirectToAction("Index");

            }



            private CategoryService CreateCategoryService()
            {
                  var userId = Guid.Parse(User.Identity.GetUserId());
                  var service = new CategoryService(userId);

                  return service;
            }
      } 
}