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
                .ForMember(destination => destination.QualificationZone,
                    member => member.MapFrom(source => source.QualificationZone.GetDescription()));
        }
    }
}
