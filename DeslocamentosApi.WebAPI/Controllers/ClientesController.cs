using DeslocamentoApi.Application.Clientes.Commands;
using DeslocamentoApi.Application.Clientes.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentosApi.WebAPI.Controllers
{
    public class ClientesController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetClientQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CadastrarClienteCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
