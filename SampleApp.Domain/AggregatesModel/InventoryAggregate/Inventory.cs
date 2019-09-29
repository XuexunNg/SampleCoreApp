using SampleApp.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace SampleApp.Domain.AggregatesModel.InventoryAggregate
{
    public partial class Inventory : Entity, IAggregateRoot
    {
        public string ProductName { get; set; }
        public string ProductSize { get; set; }
    }
}
