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
      public class StoreController : Controller
      {
            private readonly ApplicationDbContext _db = new ApplicationDbContext();
            // GET: Store
            public ActionResult Index()
            {
                  var userId = Guid.Parse(User.Identity.GetUserId());
                  var service = new StoreService(userId);
                  var model = service.GetAllStores();

                  return View(model);
            }

            public ActionResult Create()
            {
                  return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(CreateStore model)
            {
                  if (!ModelState.IsValid)
                  {
                        return View();
                  }

                  foreach (var store in _db.Stores)
                  {
                        if (store.StoreName.Equals(model.StoreName))
                        {
                              ModelState.AddModelError("", "There is a store registered with this name+\n Please choose different name");
                              return View(model);
                        }
                        else if (store.Email.Equals(model.Email))
                        {
                              ModelState.AddModelError("", "This email is already used");
                              return View(model);
                        }
                  }
                  var service = CreateStoreService();

                  if (service.CreateStore(model))
                  {
                        TempData["SaveResult"] = "Store has be created";
                        return RedirectToAction("Index");
                  }

                  ModelState.AddModelError("", "Store could not be created");

                  return View(model);
            }

            public ActionResult Detail(int storeID)
            {
                  var svc = CreateStoreService();

                  var model = svc.GetStoreByID(storeID);

                  return View(model);
            }


            public ActionResult Edit(int storeID)
            {
                  var service = CreateStoreService();

                  var detail = service.GetStoreByID(storeID);

                  var model =
              new EditStore
              {
                    StoreName = detail.StoreName,
                    Description = detail.Description,
                    Email = detail.Email,
                    Address = detail.Address,
                    Unit = detail.Unit,
                    City = detail.City,
                    State = detail.State,
                    Zip = detail.Zip,
              };
                  return View(model);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int storeID, EditStore model)
            {
                  if (!ModelState.IsValid)
                  {
                        return View(model);
                  }

                  if (model.StoreID != storeID)
                  {
                        ModelState.AddModelError("", "State name mismatch");
                        return View(model);
                  }

                  foreach (var store in _db.Stores)
                  {
                       /* if (store.StoreName.Equals(model.StoreName))
                        {
                              ModelState.AddModelError("", "There is a store registered with this name Please choose different name");
                              return View(model);
                        }*/
                        if (store.Email.Equals(model.Email))//Used to be an else if 
                        {
                              ModelState.AddModelError("", "This email is already used");
                              return View(model);
                        }
                  }
                  var service = CreateStoreService();

                  if (service.UpdateStore(model))
                  {
                        TempData["SaveResult"] = "Store has successfully upadated";
                        return RedirectToAction("Index");
                  }

                  ModelState.AddModelError("", "Store could not be updated.");
                  return View(model);
            }

            [ActionName("Delete")]
            public ActionResult Delete(int storeID)
            {
                  var toRemove = CreateStoreService();

                  var model = toRemove.GetStoreByID(storeID);


                  return View(model);
            }

            [HttpPost]
            [ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeletePost(int storeID)
            {
                  var toRemove = CreateStoreService();

                  toRemove.DeleteStoreByID(storeID);

                  TempData["SaveResult"] = "Store was successfully removed.";
                  return RedirectToAction("Index");
            }


            private StoreService CreateStoreService()
            {
                  var userId = Guid.Parse(User.Identity.GetUserId());
                  var service = new StoreService(userId);

                  return service;
            }


      }
}