using DeslocamentoApi.Application.Condutores.Commands;
using DeslocamentoApi.Application.Condutores.Query;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentosApi.WebAPI.Controllers
{
    public class CondutoresController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetCondutorQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CadastrarCondutorCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
