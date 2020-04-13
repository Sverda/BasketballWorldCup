﻿using AutoMapper;
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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody]TeamDto[] teamsDtos)
        {
            var teams = _mapper.Map<IEnumerable<Team>>(teamsDtos);
            var teamsIds = teams.Select(t => t.Id);
            var draw = _drawsService.PutIntoPots(teamsIds);
            var drawDto = _mapper.Map<DrawDto>(draw);
            return Ok(drawDto);
        }
    }
}
