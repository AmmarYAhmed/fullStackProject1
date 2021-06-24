using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTheWay.Web.Ui.Models.Enums;
using CodeTheWay.Web.Ui.Models.ViewModels;
using CodeTheWay.Web.Ui.Models.ViewModels;

namespace CodeTheWay.Web.Ui.Controllers
{
    public class BarrelController : Controller
    {
        private IBarrelService BarrelService;

        public BarrelController(IBarrelService BarrelService)
        {
            this.BarrelService = BarrelService;
        }

        public async Task<IActionResult> Index()
        {
            var barrels = await BarrelService.GetBarrels();
            var viewModels = new List<BarrelViewModel>();
            foreach (var barrel in barrels)
            {
                var volume = Math.PI * (barrel.Radius * barrel.Radius) * barrel.Height;

                
                viewModels.Add(new BarrelViewModel()
                {
                    Id = barrel.Id,
                    Contents = (Contents) barrel.Contents,
                    CurrentLocation = barrel.CurrentLocation,
                    DateCreated = barrel.DateCreated,
                    Size = Size.Small,
                });
            }

            return View(model: viewModels);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            return View(await BarrelService.GetBarrel(id));
        }
        public async Task<IActionResult> Create()
        {
            return View(new Barrel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(Barrel model)
        {
            if (ModelState.IsValid)
            {
                model.DateCreated = DateTime.UtcNow;
                var barrel = await BarrelService.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var barrel = await BarrelService.GetBarrel(id);
            await BarrelService.Delete(barrel);
            return RedirectToAction("Index");
        }




        public async Task<IActionResult> Edit(Guid id)
        {
            Barrel result = await BarrelService.GetBarrel(id);
            Barrel barrel = new Barrel()
            {
                Id = result.Id,
                Radius = result.Radius,
                Height = result.Height,
                DateCreated = result.DateCreated,
                CurrentLocation = result.CurrentLocation
            };
            return View(barrel);
        }
        public async Task<IActionResult> UpDate(Barrel model)
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
                    await BarrelService.Update(barrel);
            }
            return RedirectToAction("Index");
        }
    }
}