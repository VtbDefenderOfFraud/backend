using AutoMapper;

namespace DefenderUiGateway.Automapper
{
    public class DefenderProfile : Profile
    {
        public DefenderProfile()
        {
            CreateMap<Data.Model.User, Model.User>();
        }
    }
}
