using AdoptADrain.Areas.Manage.Models;
using AdoptADrain.DomainModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptADrain.Services
{
    public class DrainService : IDrainService
    {
        private readonly AdoptADrainDataContext _context;
        private readonly IMapper _mapper;

        public DrainService(AdoptADrainDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Create
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

        public async Task<int> CreateFlowDirection(FlowDirection flowDirection)
        {
            await _context.AddAsync(flowDirection);
            await _context.SaveChangesAsync();
            return flowDirection.FlowDirectionId;
        }
        #endregion Create
        
        #region Get
        public async Task<Drain> GetDrain(int drainId)
        {
            var drains = _context.Drain
                .Include(x => x.FlowDirection)
                .Include(x => x.RoadType)
                .Include(x => x.DrainType)
                .Include(x => x.DrainStatusHistory);

            return await drains.Where(x => x.DrainId == drainId).FirstOrDefaultAsync();
        }

        public async Task<List<DrainDTO>> GetDrainAll(DrainSearchOptions opts)
        {
            if (opts == null)
                opts = new DrainSearchOptions();

            var drains = _context.Drain
                .Include(x => x.FlowDirection)
                .Include(x => x.RoadType)
                .Include(x => x.DrainType)
                .Include(x => x.DrainStatusHistory).ThenInclude(p=>p.DrainStatus)
                .Select(x =>x);

            if (opts.FlowDirectionId > 0)
            {
               drains = drains.Where(x => x.FlowDirectionId == opts.FlowDirectionId);
            }

            if(opts.DrainTypeId > 0)
            {
                drains = drains.Where(x => x.DrainTypeId == opts.DrainTypeId);
            }

            if (opts.RoadTypeId > 0)
            {
                drains = drains.Where(x => x.RoadTypeId == opts.RoadTypeId);
            }

            if (opts.excludeAdopted)
            {
                drains = drains.Where(x => !x.IsAdopted);
            }

            if (!String.IsNullOrEmpty(opts.AdoptedUserId))
            {
                drains = drains.Where(x => x.AdoptedUserId == opts.AdoptedUserId);
            }

            List<Drain> drainList = await drains.ToListAsync();

            return _mapper.Map<List<DrainDTO>>(drainList);
        }

        public async Task<List<DrainTypeDTO>> GetDrainTypeAll()
        {
            var drainType = await _context.DrainType.ToListAsync();
            return _mapper.Map<List<DrainTypeDTO>>(drainType);
        }

        public async Task<List<FlowDirectionDTO>> GetFlowDirectionAll()
        {
            var flowDirection =  await _context.FlowDirection.ToListAsync();
            return _mapper.Map<List<FlowDirectionDTO>>(flowDirection);
        }

        public async Task<List<RoadTypeDTO>> GetRoadTypeAll()
        {
            var roadType = await _context.RoadType.ToListAsync();
            return _mapper.Map<List<RoadTypeDTO>>(roadType);
        }

        public async Task<List<DrainStatusDTO>> GetDrainStatusAll()
        {
            var drainStatus = await _context.DrainStatus.ToListAsync();
            return _mapper.Map<List<DrainStatusDTO>>(drainStatus);
        }

        #endregion Get

        public Task<int> RemoveDrain(int drainId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateDrain(Drain drain)
        {
            _context.Entry(drain).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return drain.DrainId;
        }
    }
}
