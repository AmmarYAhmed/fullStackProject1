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
        public async Task<Barrel> GetBarrel(Guid id)
        {
            return await this.BarrelRepo.GetBarrel(id);
        }

        public async Task<List<Barrel>> GetBarrels()
        {
            return await this.BarrelRepo.GetBarrels();
        }
        public async Task<Barrel> Update(Barrel barrel)
        {
            return await BarrelRepo.Update(barrel);
        }
        public async Task<Barrel> Delete(Barrel barrel)
        {
            return await BarrelRepo.Delete(barrel);
        }
    }
}
