using SampleApp.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace SampleApp.Domain.AggregatesModel.InventoryAggregate
{
    public partial class Inventory : Entity, IAggregateRoot
    {
        public string ProductName { get; private set; }
        
        
        public string ProductSize { get; private set; }
        

        public InventoryItem InventoryItem { get; set; }
       

        public Inventory(string productName, string productSize)
        {
            ProductName = productName;
            ProductSize = productSize;
        }

        public void AddInventoryItem(InventoryItem inventoryItem)
        {
            InventoryItem = inventoryItem;
         
        }
    }
}
