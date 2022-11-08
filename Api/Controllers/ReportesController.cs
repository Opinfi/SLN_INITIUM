using Application.Features.ReportesFeatures.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ReportesController : BaseApiController
    {
        /// <summary>
        /// Get Tickets by fechas.
        /// </summary>
        /// <param name="fechas"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(DateTime? fechaInicio, DateTime? fechaFin)
        {
            return Ok(await Mediator.Send(new GetReportesByFechaQuery { FechaInico = fechaInicio, FechaFin = fechaFin }));
        }
    }
}
