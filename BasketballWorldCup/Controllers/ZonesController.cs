using BasketballWorldCup.Domain.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BasketballWorldCup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonesController : ControllerBase
    {
        private readonly IZonesService _zonesService;

        public ZonesController(IZonesService zonesService)
        {
            _zonesService = zonesService;
        }

        [HttpGet]
        public IActionResult GetZones()
        {
            return Ok(_zonesService.GetZones());
        }
    }
}