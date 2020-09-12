using AutoMapper;
using BasketballWorldCup.Domain.Services.Abstractions;
using BasketballWorldCup.Mapping.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BasketballWorldCup.Model.Competition;

namespace BasketballWorldCup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        private readonly ICompetitionService _competitionService;
        private readonly IMapper _mapper;

        public CompetitionController(ICompetitionService competitionService, IMapper mapper)
        {
            _competitionService = competitionService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("firstRound/{drawId}")]
        public IActionResult FirstRound(int drawId)
        {
            // Przeprowadzenie rozgrywek Pierwszej Rundy Drużynowej
            var groupResult = _competitionService.FirstRound(drawId);
            // Podsumowanie wyników: podliczenie zwycięstw, porażek, punktów, etc.
            var resultWithSummaries = _competitionService.GroupsSummaries(groupResult);
            var dto = _mapper.Map<IEnumerable<GroupResultDto>>(resultWithSummaries);
            return Ok(dto);
        }

        [HttpGet]
        [Route("secondRound/{drawId}")]
        public IActionResult SecondRound(int drawId)
        {
            // Przeprowadzenie rozgrywek Drugiej Rundy Drużynowej
            var groupResult = _competitionService.SecondRound(drawId);
            // Podsumowanie wyników: podliczenie zwycięstw, porażek, punktów, etc.
            var resultWithSummaries = _competitionService.GroupsSummaries(groupResult);
            var dto = _mapper.Map<IEnumerable<GroupResultDto>>(resultWithSummaries);
            return Ok(dto);
        }

        [HttpGet]
        [Route("finalRound/{drawId}")]
        public IActionResult FinalRound(int drawId)
        {
            var result = new List<GroupResult>();

            // Przeprowadzenie rozgrywek ćwierćfinałów
            var quarterResult = _competitionService.QuarterFinals(drawId);
            // Podsumowanie wyników: podliczenie zwycięstw, porażek, punktów, etc.
            var quarterWithSummaries = _competitionService.GroupsSummaries(quarterResult);
            result.AddRange(quarterWithSummaries);

            // Przeprowadzenie rozgrywek półfinałów
            var semiResult = _competitionService.SemiFinals(drawId);
            // Podsumowanie wyników: podliczenie zwycięstw, porażek, punktów, etc.
            var semiWithSummaries = _competitionService.GroupsSummaries(semiResult);
            result.AddRange(semiWithSummaries);

            // Przeprowadzenie rozgrywek finałów
            var finalsResult = _competitionService.FinalRound(drawId);
            // Podsumowanie wyników: podliczenie zwycięstw, porażek, punktów, etc.
            var finalsWithSummaries = _competitionService.GroupsSummaries(finalsResult);
            result.AddRange(finalsWithSummaries);

            var dto = _mapper.Map<IEnumerable<GroupResultDto>>(result);
            return Ok(dto);
        }
    }
}