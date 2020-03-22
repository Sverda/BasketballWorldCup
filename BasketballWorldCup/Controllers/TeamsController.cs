using AutoMapper;
using BasketballWorldCup.Domain.Services.Abstractions;
using BasketballWorldCup.Mapping.Dto;
using BasketballWorldCup.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BasketballWorldCup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService _teamsService;
        private readonly IMapper _mapper;

        public TeamsController(ITeamsService teamsService, IMapper mapper)
        {
            _teamsService = teamsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTeams()
        {
            var teams = _teamsService.GetTeams();
            var dto = _mapper.Map<IEnumerable<TeamDto>>(teams);
            return Ok(dto);
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
            var dto = _mapper.Map<IEnumerable<TeamDto>>(teams);
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult AddTeam([FromBody] TeamDto team)
        {
            var teamToAdd = _mapper.Map<Team>(team);
            var addedTeam = _teamsService.AddTeam(teamToAdd);
            var dto = _mapper.Map<TeamDto>(addedTeam);
            return Ok(dto);
        }

        [HttpDelete]
        [Route("{teamId}")]
        public IActionResult DeleteTeam(int teamId)
        {
            var deletedTeam = _teamsService.DeleteTeam(teamId);
            var dto = _mapper.Map<TeamDto>(deletedTeam);
            return Ok(dto);
        }
    }
}