using AdoptADrain.Areas.Adopt.Models;
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

        public Task<Drain> GetDrain(int drainId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Drain>> GetDrainAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<FlowDirectionDTO>> GetFlowDirectionAll()
        {
            var flowDirection =  await _context.FlowDirection.ToListAsync();
            return _mapper.Map<List<FlowDirectionDTO>>(flowDirection);
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
