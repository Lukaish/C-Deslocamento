using DeslocamentoApi.Application.Deslocamentos.Commands;
using DeslocamentoApi.Application.Deslocamentos.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentosApi.WebAPI.Controllers
{
    public class DeslocamentosController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetDeslocamentoQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{deslocamentoId:long}")]
        public async Task<IActionResult> GetSync(long deslocamentoId)
        {
            var query = new GetDeslocamentoQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CadastroDeslocamentoCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
        [HttpPut("{deslocamentoId:long}/Fim_do_deslocamento")]
         public async Task<IActionResult> PutAdicionarSignatarioAsync(
        [FromRoute] long deslocamentoId,
        [FromBody] FimDeslocamento command
             )
         {
             if (deslocamentoId != command.DeslocamentoId) return BadRequest();

             var result = await Mediator.Send(command);
             return Ok(result);
         }
    } 
 }
