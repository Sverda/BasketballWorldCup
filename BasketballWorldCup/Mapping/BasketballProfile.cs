using AutoMapper;
using BasketballWorldCup.Mapping.Dto;
using BasketballWorldCup.Model;
using BasketballWorldCup.Model.Helpers;

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
                    member => member.MapFrom(dto => dto.QualificationZone.GetEnumFromDescription<QualificationZone>()));
        }
    }
}
