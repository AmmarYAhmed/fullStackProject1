using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}