using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.API.Application.Queries
{
    public class InventoryQueries : IInventoryQueries
    {
        private string _connectionString = string.Empty;

        public InventoryQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<InventoryItem> GetInventoryItemAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"select [ProductName] from [SampleAppDB] WHERE [Id]=@id"
                        , new { id }
                    );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapOrderItems(result);
            }
        }

        private InventoryItem MapOrderItems(dynamic result)
        {
            var inventoryItem = new InventoryItem
            {
                ProductName = result[0].productname,

            };

            return inventoryItem;
        }
    }

   
}
