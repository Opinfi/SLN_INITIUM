using Application.Features.ColaFeatures.Commands.CreateCola;
using Application.Features.ColaFeatures.Commands.UpdateCola;
using Application.Features.ColaFeatures.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ColaController : BaseApiController
    {

        /// <summary>
        /// Get Clientes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetColaListQuery()));
        }

        /// <summary>
        /// Get Cliente by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await Mediator.Send(new GetColaQuery { Id = id }));
        }

        /// <summary>
        /// Creates a New Cliente.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateColaCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Updates the Cliente Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Edit(UpdateColaCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
