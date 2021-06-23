using CodeTheWay.Web.Ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Services
{
    public interface IBarrelService
    {
        public Task<Barrel> Create(Barrel barrel);

        public Task<List<Barrel>> GetBarrels();
    }
}
