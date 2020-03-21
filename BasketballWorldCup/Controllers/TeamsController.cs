using BasketballWorldCup.Domain.Services.Abstractions;
using BasketballWorldCup.Model;
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

        [HttpGet]
        [Route("{tier}")]
        public IActionResult GetTeamsByTier(int tier)
        {
            if (tier < 0 || tier >= 4)
            {
                return BadRequest("There are only four tiers");
            }

            var teams = _teamsService.GetTeamsByTier((Tier)tier);
            return Ok(teams);
        }

        [HttpPost]
        public IActionResult AddTeam([FromBody] Team team)
        {
            var addedTeam = _teamsService.AddTeam(team);

            return Ok(addedTeam);
        }

        [HttpDelete]
        [Route("{teamId}")]
        public IActionResult DeleteTeam(int teamId)
        {
            var deletedTeam = _teamsService.DeleteTeam(teamId);

            return Ok(deletedTeam);
        }
    }
}