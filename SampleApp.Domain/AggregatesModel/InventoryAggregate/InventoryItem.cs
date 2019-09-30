using SampleApp.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace SampleApp.Domain.AggregatesModel.InventoryAggregate
{
    public partial class InventoryItem : Entity, IAggregateRoot
    {
        public string Type { get; set; }

        
        public Guid InventoryId { get; set; }


    }
}
