using AutoMapper;

namespace Bki.Automapper
{
    public class DefenderProfile : Profile
    {
        public DefenderProfile() =>
            CreateMap<Model.Data.Credit, Model.Controllers.Credit>()
                .ForMember(c => c.Requested, o => o.MapFrom(c => c.Created));
    }
}