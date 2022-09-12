using Application.Features.Models.Models;
using Application.Features.Models.Queries;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery request = new() { PageRequest = pageRequest };
            
            ModelListModel response = await Mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody]Dynamic dynamic)
        {
            GetListModelByDynamicQuery request = new() { PageRequest = pageRequest, Dynamic = dynamic };

            ModelListModel response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
