using SampleApp.Domain.AggregatesModel.InventoryAggregate;
using SampleApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.Infrastructure.Repositories
{
    public class InventoryRepository: IInventoryRepository
    {

        private readonly SampleAppDBContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public InventoryRepository(SampleAppDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Inventory Add(Inventory inventory)
        {
            return _context.Inventory.Add(inventory).Entity;
        }

        public async Task<Inventory> FindAsync(string productName)
        {
            var item = _context.Inventory.SingleOrDefault(c => c.ProductName == productName);
   
            return item;
        }

        public Task<Inventory> FindByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
