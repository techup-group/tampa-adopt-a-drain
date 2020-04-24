using AdoptADrain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptADrain.Services
{
    public class DrainService : IDrainService
    {
        private readonly AdoptADrainDataContext _context;

        public DrainService(AdoptADrainDataContext context)
        {
            _context = context;
        }

        public async Task<int> CreateDrain(Drain drain)
        {
            await _context.AddAsync(drain);
            await _context.SaveChangesAsync();
            return drain.DrainId;
        }

        public async Task<int> CreateDrainStatusHistory(DrainStatusHistory drainStatusHistory)
        {
            await _context.AddAsync(drainStatusHistory);
            await _context.SaveChangesAsync();
            return drainStatusHistory.DrainStatusHistoryId;
        }

        public Task<Drain> GetDrain(int drainId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Drain>> GetDrainAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveDrain(int drainId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateDrain(Drain drain)
        {
            throw new NotImplementedException();
        }
    }
}
