using AutoMapper;
using BasketballWorldCup.Domain.Services.Abstractions;
using BasketballWorldCup.Mapping.Dto;
using BasketballWorldCup.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BasketballWorldCup.Controllers
{
    [Route("api/[controller]")]
    public class DrawsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDrawsService _drawsService;

        public DrawsController(IMapper mapper, IDrawsService drawsService)
        {
            _mapper = mapper;
            _drawsService = drawsService;
        }

        [HttpGet("{drawId}")]
        public IActionResult Get(int drawId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody]TeamDto[] teamsDtos)
        {
            // TODO: Send only Ids from client app
            var teams = _mapper.Map<IEnumerable<Team>>(teamsDtos);
            var teamsIds = teams.Select(t => t.Id);
            var draw = _drawsService.SeedPots(teamsIds);
            var drawDto = _mapper.Map<DrawDto>(draw);
            return Ok(drawDto);
        }

        [HttpPatch]
        [Route("{drawId}")]
        public IActionResult Patch(int drawId)
        {
            var draw = _drawsService.AssignGroups(drawId);
            var drawDto = _mapper.Map<DrawDto>(draw);
            return Ok(drawDto);
        }
    }
}
