using Microsoft.AspNetCore.Mvc;



namespace DeslocamentosApi.WebAPI.Controllers
{
    public class CarroController : ApiController    
    {

        [HttpGet]
        public async Task<IActionResult> GetSync([FromQuery] GetCarroQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
