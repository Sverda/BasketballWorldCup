using AutoMapper;
using BasketballWorldCup.Mapping.Dto;
using BasketballWorldCup.Model;
using BasketballWorldCup.Model.Helpers;
using System.Linq;

namespace BasketballWorldCup.Mapping
{
    public class BasketballProfile : Profile
    {
        public BasketballProfile()
        {
            CreateMap<Team, TeamDto>()
                .ForMember(dto => dto.QualificationZone,
                    member => member.MapFrom(team => team.QualificationZone.GetDescription()))
                .ForMember(dto => dto.IsSelected, opt => opt.Ignore());
            CreateMap<TeamDto, Team>()
                .ForMember(team => team.QualificationZone,
                    member => member.MapFrom(dto => dto.QualificationZone.GetEnumFromDescription<QualificationZone>()))
                .ForMember(team => team.TeamPots, opt => opt.Ignore());

            CreateMap<Draw, DrawDto>()
                .ForMember(dto => dto.Pots, member => member.MapFrom(draw => draw.Pots));
            CreateMap<DrawDto, Draw>()
                .ForMember(draw => draw.Pots, member => member.MapFrom(dto => dto.Pots));

            CreateMap<Pot, PotDto>()
                .ForMember(dto => dto.Teams, member => member.MapFrom(pot => pot.TeamPots.Select(tp => tp.Team)));
        }
    }
}
