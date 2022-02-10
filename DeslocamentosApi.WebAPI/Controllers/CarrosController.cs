using DeslocamentoApp.Application.CarrosCommands;
using Microsoft.AspNetCore.Mvc;



namespace DeslocamentosApi.WebAPI.Controllers
{
    public class CarrosController : ApiController    
    {

        [HttpGet]
        public async Task<IActionResult> GetSync([FromQuery] GetCarroQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarCarroCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
