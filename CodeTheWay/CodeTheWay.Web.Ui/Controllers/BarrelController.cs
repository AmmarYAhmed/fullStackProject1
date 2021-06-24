using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeTheWay.Web.Ui.Models.Enums;
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

        public async Task<IActionResult> Index(Size sizeFilter = Size.All, Contents contentsFilter = Contents.All)
        {
            var barrels = await BarrelService.GetBarrels();
            var viewModels = new List<BarrelViewModel>();
            foreach (var barrel in barrels)
            {
                if(contentsFilter != Contents.All)
                    if (barrel.Contents != (int)contentsFilter)
                        continue;
                
                var volume = Math.PI * (barrel.Radius * barrel.Radius) * barrel.Height;
                var size = Size.Small;

                // Height of 20, Radius of 8 yields Medium
                // Radius of 7 yields Small
                if (volume <= 3465) // ≈ 15 Gallons
                    size = Size.Small;
                else if (volume <= 6930) // ≈ 30 Gallons
                    size = Size.Medium;
                else
                    size = Size.Large;
                
                if(sizeFilter != Size.All)
                    if (size != sizeFilter)
                        continue;
                
                viewModels.Add(new BarrelViewModel()
                {
                    Id = barrel.Id,
                    Contents = (Contents) barrel.Contents,
                    CurrentLocation = barrel.CurrentLocation,
                    DateCreated = barrel.DateCreated,
                    Size = size,
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
            return View(result);
        }
        
        public async Task<IActionResult> UpDate(Barrel model)
        {
            if (ModelState.IsValid)
            {
                await BarrelService.Update(model);
            }
            return RedirectToAction("Index");
        }
    }
}