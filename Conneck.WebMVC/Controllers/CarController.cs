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
      [Authorize]
      public class CarController : Controller
      {
            // GET: Car
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
                  // this method will make sure the model is valid, grabs the current userid,
                  // calls on in model create and returns the ser back to the index view
                  if (!ModelState.IsValid)
                  {
                        return View(model);
                  }

                  var service = CreateCarService();

                  if (service.CreateCar(model))
                  {

                        TempData["SaveResult"] = "Item was added."; // The temdata removes the information after it
                        return RedirectToAction("Index");
                  }

                  ModelState.AddModelError("", "Item could not be added");

                  return View(model);
            }

            public ActionResult Details(int carID)
            {

                  var svc = CreateCarService();

                  var model = svc.GetCarByID(carID);


                  return View(model);
            }


            public ActionResult Edit(int carID)
            {
                  var service = CreateCarService();

                  var detail = service.GetCarByID(carID);


                  var model = new CarEdit
                  {
                        CarID = detail.CarID,
                        Make = detail.Make,
                        CarM = detail.CarM,
                        Color = detail.Color,                  
                        LicensePlate = detail.LincesePlate,
                        AdminID = detail.AdminID,
                                         
                  };
                  return View(model);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int carID, CarEdit model)
            {
                  if (!ModelState.IsValid)
                  {
                        return View(model);
                  }

                  if (model.CarID != carID)
                  {
                        ModelState.AddModelError("", "VIN does not match.");
                        return View(model);
                  }

                  var service = CreateCarService();

                  if (service.UpdateCar(model))
                  {
                        TempData["SaveResult"] = "Content was Updated."; // The temdata removes the information after it
                        return RedirectToAction("Index");
                  }

                  ModelState.AddModelError("", "Content could not be Updated.");

                  return View(model);
            }

            [ActionName("Delete")]
            public ActionResult Delete(int carID)
            {
                  var svc = CreateCarService();

                  var model = svc.GetCarByID(carID);

                  return View(model);
            }

            [HttpPost]
            [ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeletePost(int cardID)
            {
                  var service = CreateCarService();

                  service.DeleteCarByCardID(cardID);

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