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

      public class AdminController : Controller
      {
            private readonly ApplicationDbContext _db = new ApplicationDbContext();

            // GET: Admin
            public ActionResult Index()
            {
                  var userId = Guid.Parse(User.Identity.GetUserId());
                  var service = new AdminService(userId);
                  var model = service.GetAdmins();

                  return View(model);

            }


            public ActionResult Create()
            {
                  return View();

            }

            //This method makes sure the model is valid, grabs the current userId,and return the user to the index view
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(CreateAdmin model)
            {

                  if (!ModelState.IsValid)
                  {
                        return View(model);
                  }

                 
                  foreach(var kvp in _db.Admins)
                  {
                        if (kvp.FirstName.Equals(model.FirstName) && kvp.LastName.Equals(model.LastName))
                        {

                              ModelState.AddModelError("", "Admin already exist");
                              return View(model);

                        }
                        if (kvp.Email.Equals(model.Email))
                        {
                              ModelState.AddModelError("", "This email is already used .");
                              return View(model);
                        }
                  }

                  var service = CreateAdminService();

                  if (service.CreateAdmin(model))
                  {
                        TempData["SaveResult"] = "Admin Account was successfully created.";
                        return RedirectToAction("Index");
                  };

                  ModelState.AddModelError("", "Admin Account could not be created.");

                  return View(model);

            }

            public ActionResult Details(int adminID)
            {
                  var svc = CreateAdminService();

                  var model = svc.GetAdminById(adminID);

                  return View(model);

            }

            public ActionResult Edit(int adminID)
            {
                  var service = CreateAdminService();

                  var detail = service.GetAdminById(adminID);

                  var model =
                        new EditAdmin
                        {
                              FirstName = detail.FirstName,
                              LastName = detail.LastName,
                              Phone = detail.Phone,
                              Email = detail.Email,

                        };

                  return View(model);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int adminID, EditAdmin model)
            {
                  if (!ModelState.IsValid)
                  {
                        return View(model);
                  }

                  if (model.AdminID != adminID)
                  {
                        ModelState.AddModelError("", "Admin Id Invalid");
                        return View(model);
                  }

                  var service = CreateAdminService();

                  if (service.UpdateAdmin(model))
                  {
                        TempData["SaveResult"] = "Admin Account was successfully Update.";
                        return RedirectToAction("Index");
                  }

                  ModelState.AddModelError("", "Admin Account could not be updated.");
                  return View(model);
            }


            [ActionName("Delete")]
            public ActionResult Delete(int adminID)
            {
                  var svc = CreateAdminService();

                  var model = svc.GetAdminById(adminID);

                  return View(model);

            }

            [HttpPost]
            [ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeletePost(int adminID)
            {
                  var service = CreateAdminService();

                  service.DeleteNote(adminID);

                  TempData["SaveResult"] = "Admin Account  was successfully deleted";

                  return RedirectToAction("Index");
            }


            private AdminService CreateAdminService()
            {
                  var userId = Guid.Parse(User.Identity.GetUserId());
                  var service = new AdminService(userId);
                  return service;
            }
      }
}