using SampleApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SampleApp.Domain.AggregatesModel.InventoryAggregate
{

    public interface IInventoryRepository : IRepository<Inventory>
    {
        Inventory Add(Inventory inventory);
        Task<Inventory> FindAsync(string productName);
        Task<Inventory> FindByIdAsync(string id);
    }
}
