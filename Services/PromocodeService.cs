using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Db;
using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class PromocodeService : IPromocodeService
    {
        Context _context;

        public PromocodeService(Context context)
        {
            _context = context;
        }

        public async Task<Promocode> CreatePromocode(Promocode promocode)
        {
            await _context.Promocodes.AddAsync(promocode);
            await _context.SaveChangesAsync();
            return promocode;
        }

        public async Task DeletePromocode(int id)
        {
            _context.Promocodes.Remove(await _context.Promocodes.FirstOrDefaultAsync(x=>x.Id==id));
            await _context.SaveChangesAsync();
        }

        public async Task<Promocode> GetPromocodeByCode(string code)
        {
            return await _context.Promocodes.FirstOrDefaultAsync(x=>x.Code==code);
        }

        public async Task<Promocode> GetPromocodeById(int id)
        {
            return await _context.Promocodes.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<List<Promocode>> GetPromocodes()
        {
            return await _context.Promocodes.AsNoTracking().ToListAsync();
        }

        public async Task<Promocode> IncreaseUsedTimes(int id)
        {
            Promocode prom = await _context.Promocodes.FirstOrDefaultAsync(x=>x.Id==id);
            prom.UsedTimes+=1;
            _context.Promocodes.Update(prom);
            await _context.SaveChangesAsync();
            return prom;
        }

        public bool IsAvailable(Promocode promocode)
        {
            if(promocode==null) return false;
            DateTime now = DateTime.Now;
            bool promocodeIsAvailable = ( promocode.AvailableFrom < now && promocode.AvailableTo > now  );
            return promocodeIsAvailable;
        }

        public async Task<Promocode> UpdatePromocode(Promocode promocode)
        {
            _context.Promocodes.Update(promocode);
            await _context.SaveChangesAsync();
            return promocode;
        }
    }
}