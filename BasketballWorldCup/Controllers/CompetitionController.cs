using AutoMapper;
using BasketballWorldCup.Domain.Services.Abstractions;
using BasketballWorldCup.Mapping.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            var groupResult = _competitionService.FinalRound(drawId);
            var resultWithSummaries = _competitionService.GroupsSummaries(groupResult);
            var dto = _mapper.Map<IEnumerable<GroupResultDto>>(resultWithSummaries);
            return Ok(dto);
        }
    }
}