using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Controllers
{
    public class BarrelController : Controller
    {
        private IBarrelService BarrelService;

        public BarrelController(IBarrelService BarrelService)
        {
            this.BarrelService = BarrelService;
        }
        public IActionResult Index()
        {
            return View();
        }




        public async Task<IActionResult> Edit(Guid id)
        {
            Barrel result = await BarrelService.GetBarrel(id);
            BarrelRegistrationViewModel barrel = new BarrelRegistrationViewModel()
            {
                Id = result.Id,
                Radius = result.Radius,
                Height = result.Height,
                DateCreated = result.DateCreated,
                CurrentLocation = result.CurrentLocation
            };
            return View(barrel);
        }
        public async Task<IActionResult> UpDate(BarrelRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                    Barrel barrel = new Barrel()
                    {
                        Id = model.Id,
                        Radius = model.Radius,
                        Height = model.Height,
                        DateCreated = model.DateCreated,
                        CurrentLocation = model.CurrentLocation
                    };
                    Barrel barrel = await BarrelService.Update(barrel);
            }
            return RedirectToAction("Index");
        }
    }
}
