using Conneck.Models.Car;
using Conneck.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conneck.WebMVC.Controllers
{
      public class CarController : Controller
      {
            // GET: Car
            [Authorize]
            public ActionResult Index()
            {
                  var userId = Guid.Parse(User.Identity.GetUserId());
                  var service = new CarService(userId);
                  var model = service.GetCars();

                  return View(model);
            }

            public ActionResult Create()
            {
                  return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(CarCreate model)
            {
                  // this method will make sure the madel is valid, grabs the current userid,
                  // calls on in model create and returns the ser back to the idex view
                  if (!ModelState.IsValid)
                  {
                        return View(model);
                  }

                  var service = CreateCarService();

                  if (service.CreateCar(model))
                  {
                        TempData["SaveResult"] = "Car was added."; // The temdata removes the information after it
                        return RedirectToAction("Index");
                  }

                  ModelState.AddModelError("", "Car could not be added");

                  return View(model);
            }

            public ActionResult Details(int id)
            {
                  var svc = CreateCarService();
                  var model = svc.GetCarById(id);

                  return View(model);
            }


            public ActionResult Edit(int id)
            {
                  var service = CreateCarService();
                  var detail = service.GetCarById(id);

                  var model = new CarEdit
                  {
                        CarID = detail.CarID,
                        CarName = detail.CarName,
                        Brand = detail.Brand,
                        Color = detail.Color,
                        PlateNumber = detail.PlateNumber,
                  };

                  return View(model);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int id, CarEdit model)
            {
                  if (!ModelState.IsValid)
                  {
                        return View(model);
                  }

                  if(model.CarID != id)
                  {
                        ModelState.AddModelError("", "Id Mismatch");
                  }

                  var serice = CreateCarService();

                  if (serice.UpdateCar(model))
                  {
                        TempData["SaveResult"] = "Car was Updated."; // The temdata removes the information after it
                        return RedirectToAction("Index");
                  }

                  ModelState.AddModelError("", "Car could not be Updated.");

                  return View(model);
            }

            [ActionName("Delete")]
            public ActionResult Delete(int id)
            {
                  var svc = CreateCarService();
                  var model = svc.GetCarById(id);

                  return View(model);
            }

            [HttpPost]
            [ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeletePost(int id)
            {
                  var service = CreateCarService();

                  service.DeleteCarId(id);

                  TempData["SaveResult"] = "Car was Deleted."; // The temdata removes the information after it
                  return RedirectToAction("Index");
            }


            private CarService CreateCarService()
            {
                  var userId = Guid.Parse(User.Identity.GetUserId());
                  var service = new CarService(userId);
                  return service;
            }
      }
}