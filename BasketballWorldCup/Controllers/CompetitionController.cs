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
            var groupResult = _competitionService.FirstRound(drawId);
            var resultWithSummaries = _competitionService.GroupsSummaries(groupResult);
            var dto = _mapper.Map<IEnumerable<GroupResultDto>>(resultWithSummaries);
            return Ok(dto);
        }

        [HttpGet]
        [Route("secondRound/{drawId}")]
        public IActionResult SecondRound(int drawId)
        {
            var groupResult = _competitionService.SecondRound(drawId);
            var resultWithSummaries = _competitionService.GroupsSummaries(groupResult);
            var dto = _mapper.Map<IEnumerable<GroupResultDto>>(resultWithSummaries);
            return Ok(dto);
        }

        [HttpGet]
        [Route("finalRound/{drawId}")]
        public IActionResult FinalRound(int drawId)
        {
            var quarterResult = _competitionService.QuarterFinals(drawId);
            var quarterWithSummaries = _competitionService.GroupsSummaries(quarterResult);

            var semiResult = _competitionService.SemiFinals(drawId);
            var semiWithSummaries = _competitionService.GroupsSummaries(semiResult);

            var result = new List<GroupResult>();
            result.AddRange(quarterWithSummaries);
            result.AddRange(semiWithSummaries);
            var dto = _mapper.Map<IEnumerable<GroupResultDto>>(result);
            return Ok(dto);
        }
    }
}