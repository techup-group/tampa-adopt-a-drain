using AdoptADrain.Areas.Manage.Models;
using AdoptADrain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptADrain.Services
{
    public interface IDrainService
    {
        /// <summary>
        /// Add Drain
        /// </summary>
        /// <param name="drain"></param>
        /// <returns>DrainId Created</returns>
        Task<int> CreateDrain(Drain drain);

        /// <summary>
        /// Update Drain
        /// </summary>
        /// <param name="drain"></param>
        /// <returns>DrainId Updated</returns>
        Task<int> UpdateDrain(Drain drain);

        /// <summary>
        /// Remove Drain
        /// </summary>
        /// <param name="drainId"></param>
        /// <returns>DrainId Removed</returns>
        Task<int> RemoveDrain(int drainId);

        /// <summary>
        /// Add Drain Status History
        /// </summary>
        /// <param name="drainStatusHistory"></param>
        /// <returns>DrainStatusHistoryId Created</returns>
        Task<int> CreateDrainStatusHistory(DrainStatusHistory drainStatusHistory);

        /// <summary>
        /// Get All Drains
        /// </summary>
        /// <returns>Drain List</returns>
        Task<List<DrainDTO>> GetDrainAll(DrainSearchOptions opts);

        /// <summary>
        /// Get Drain
        /// </summary>
        /// <param name="drainId"></param>
        /// <returns>Drain</returns>
        Task<Drain> GetDrain(int drainId);

        /// <summary>
        /// Create Flow Direction
        /// </summary>
        /// <param name="flowDirection"></param>
        /// <returns>FlowDirectionId Created</returns>
        Task<int> CreateFlowDirection(FlowDirection flowDirection);

        /// <summary>
        /// Get All Drains
        /// </summary>
        /// <returns>Drain List</returns>
        Task<List<FlowDirectionDTO>> GetFlowDirectionAll();

    }
}
