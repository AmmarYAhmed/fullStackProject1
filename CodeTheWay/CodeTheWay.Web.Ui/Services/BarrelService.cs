using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Services
{
    public class BarrelService : IBarrelService
    {
        private IBarrelRepository BarrelRepo;

        public BarrelService(AppDbContext dbContext) 
        {
            this.BarrelRepo = new BarrelRepository(dbContext);
        }

        public async Task<Barrel> Create(Barrel barrel)
        {
            return await this.BarrelRepo.Create(barrel);
        }

        public async Task<List<Barrel>> GetBarrels()
        {
            return await this.BarrelRepo.GetBarrels();
        }
    }
}
