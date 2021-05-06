using AutoMapper;

namespace DefenderUiGateway.Automapper
{
    public class DefenderProfile : Profile
    {
        public DefenderProfile()
        {
            CreateMap<Data.Model.User, Model.User>();

            CreateMap<Data.Model.Credit, Model.CreditInfoItem>()
                .ForMember(d => d.State, o => o.MapFrom(s => s.StateId))
                .ForMember(d => d.BankName, o => o.MapFrom(s => s.Bank.Name));
        }
    }
}