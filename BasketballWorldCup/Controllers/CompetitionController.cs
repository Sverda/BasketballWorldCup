using AutoMapper;
using BasketballWorldCup.Domain.Services.Abstractions;
using BasketballWorldCup.Mapping.Dto;
using BasketballWorldCup.Model.Competition;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
            var summary = _competitionService.GroupsSummaries(groupResult);
            var dto = _mapper.Map<IEnumerable<GroupResultDto>>(groupResult);
            AssignSummariesToGroups(summary, dto);
            return Ok(dto);
        }

        private static void AssignSummariesToGroups(IEnumerable<GroupSummary> summary, IEnumerable<GroupResultDto> dto)
        {
            foreach (var groupSummary in summary)
            {
                var group = dto.Single(d => d.GroupLetter == groupSummary.Letter);
                group.GroupSummary = groupSummary;
            }
        }
    }
}