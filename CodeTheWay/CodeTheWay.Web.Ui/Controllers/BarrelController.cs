using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var barrel = await BarrelService.GetBarrel(id);
            await BarrelService.Delete(barrel);
            return RedirectToAction("Index");
        }
    }
}
