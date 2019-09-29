using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleApp.API.Application.Commands;
using SampleApp.API.Application.Queries;

namespace SampleApp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IInventoryQueries _inventoryQueries;

        public InventoryController(
            IMediator mediator,
            IInventoryQueries inventoryQueries
           )
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _inventoryQueries = inventoryQueries ?? throw new ArgumentNullException(nameof(inventoryQueries));
        }

        [Route("{orderId:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(InventoryItem), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetOrderAsync(int orderId)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var order = await _inventoryQueries.GetInventoryItemAsync(orderId);

                return Ok(order);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("create")]
        [HttpPost]
        public async Task<bool> CreateItemAsync([FromBody] CreateItemCommand createItemCommand)
        {
            return await _mediator.Send(createItemCommand);
        }
    }
}
