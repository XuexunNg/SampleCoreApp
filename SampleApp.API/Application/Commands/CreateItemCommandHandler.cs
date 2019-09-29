using MediatR;
using SampleApp.Domain.AggregatesModel.InventoryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.API.Application.Commands
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, bool>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMediator _mediator;

        public CreateItemCommandHandler(IMediator mediator,
            IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateItemCommand message, CancellationToken cancellationToken)
        {
            var inventory = new Inventory(message.ProductName, message.ProductSize);
            inventory.AddInventoryItem(new InventoryItem() { Type = "thimbdrive" });
            _inventoryRepository.Add(inventory);

            return await _inventoryRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
