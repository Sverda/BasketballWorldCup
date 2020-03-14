using BasketballWorldCup.Domain.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BasketballWorldCup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService _teamsService;

        public TeamsController(ITeamsService teamsService)
        {
            _teamsService = teamsService;
        }

        [HttpGet]
        public IActionResult GetTeams()
        {
            var teams = _teamsService.GetTeams();
            return Ok(teams);
        }
    }
}