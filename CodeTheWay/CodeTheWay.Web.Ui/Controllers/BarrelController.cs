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

    }
}
