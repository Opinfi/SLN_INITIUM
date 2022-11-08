using Application.Features.TicketFeatures.Commands;
using Application.Features.TicketFeatures.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class TicketsController : BaseApiController
    {
        /// <summary>
        /// Get a New Cliente.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Registrar")]
        public async Task<IActionResult> Create()
        {
            return Ok(await Mediator.Send(new GetNewCreateTicket()));
        }
        /// <summary>
        /// Creates a New Cliente.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Get Clientes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetTicketListQuery()));
        }

        /// <summary>
        /// Get Cliente by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await Mediator.Send(new GetTicketQuery { Id = id }));
        }
    }
}
