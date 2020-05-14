using AutoMapper;
using BasketballWorldCup.Mapping.Dto;
using BasketballWorldCup.Model;
using BasketballWorldCup.Model.Competition;
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
                .ForMember(dto => dto.Pots, member => member.MapFrom(draw => draw.Pots))
                .ForMember(dto => dto.Groups, member => member.MapFrom(draw => draw.Groups));

            CreateMap<Pot, PotDto>()
                .ForMember(dto => dto.Teams, member => member.MapFrom(pot => pot.TeamPots.Select(tp => tp.Team)));

            CreateMap<Group, GroupDto>()
                .ForMember(dto => dto.Letter, member => member.MapFrom(group => group.Letter))
                .ForMember(dto => dto.Teams, member => member.MapFrom(group => group.TeamGroups.Select(tg => tg.Team)));

            CreateMap<PlayResult, PlayResultDto>()
                .ForMember(dto => dto.TeamId, member => member.MapFrom(play => play.Team.Id))
                .ForMember(dto => dto.PointsFor, member => member.MapFrom(play => play.PointsFor))
                .ForMember(dto => dto.PointsAgainst, member => member.MapFrom(play => play.PointsAgainst));

            CreateMap<MatchResult, MatchResultDto>()
                .ForMember(dto => dto.Host, member => member.MapFrom(match => match.Host))
                .ForMember(dto => dto.Guest, member => member.MapFrom(match => match.Guest));

            CreateMap<GroupResult, GroupResultDto>()
                .ForMember(dto => dto.GroupLetter, member => member.MapFrom(group => group.Group.Letter))
                .ForMember(dto => dto.MatchResults, member => member.MapFrom(group => group.MatchResults));
        }
    }
}
