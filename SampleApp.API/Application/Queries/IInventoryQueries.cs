
using System.Threading.Tasks;

namespace SampleApp.API.Application.Queries
{
    public interface IInventoryQueries
    {
        Task<InventoryItem> GetInventoryItemAsync(int id);
    }
}
