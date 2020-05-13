using BasketballWorldCup.Domain.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BasketballWorldCup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        private readonly ICompetitionService _competitionService;

        public CompetitionController(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        [HttpPost]
        [Route("firstRound/{drawId}")]
        public IActionResult FirstRound(int drawId)
        {
            var groupsResult = _competitionService.FirstRound(drawId);
            return Ok(groupsResult);
        }
    }
}