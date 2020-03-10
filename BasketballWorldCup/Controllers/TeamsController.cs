using BasketballWorldCup.Model;
using Microsoft.AspNetCore.Mvc;

namespace BasketballWorldCup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTeams()
        {
            var teams = new[]
            {
                new Team {Id = 1, Name = "Poland"},
                new Team {Id = 2, Name = "United Kingdoms"}
            };
            return Ok(teams);
        }
    }
}