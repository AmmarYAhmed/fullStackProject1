using CodeTheWay.Web.Ui.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CodeTheWay.Web.Ui.Repositories
{
    public class BarrelRepository : IBarrelRepository
    {
        private AppDbContext AppDbContext;

        public BarrelRepository(AppDbContext dbContext)
        {
            this.AppDbContext = dbContext;
        }

        public async Task<Barrel> Create(Barrel barrel)
        {
            var result = await this.AppDbContext.AddAsync(barrel);
            await this.AppDbContext.SaveChangesAsync();

            return result.Entity;
        }
        public async Task<Barrel> GetBarrel(Guid id)
        {
            return await AppDbContext.Barrels.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Barrel>> GetBarrels()
        {
            return await this.AppDbContext.Barrels.ToListAsync();
        }
        public async Task<Barrel> Update(Barrel model)
        {
            var result = AppDbContext.Barrels.Update(model);
            await AppDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Barrel> Delete(Barrel model)
        {
            AppDbContext.Barrels.Remove(model);
            await AppDbContext.SaveChangesAsync();
            return model;
        }
    }
}
