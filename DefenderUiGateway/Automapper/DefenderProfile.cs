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
                .ForMember(d => d.BankName, o => o.MapFrom(s => s.Bank.Name))
                .ForMember(d => d.BankIcoUrl, o => o.MapFrom(s => s.Bank.IcoUrl));

            CreateMap<Data.Model.CreditRequest, Model.CreditOrder>()
                .ForMember(d => d.BankName, o => o.MapFrom(s => s.Bank.Name))
                .ForMember(d => d.BankIcoUrl, o => o.MapFrom(s => s.Bank.IcoUrl))
                .ForMember(d => d.RegistrationNumber, o => o.MapFrom(s => s.Bank.RegistrationNumber))
                .ForMember(d => d.Tin, o => o.MapFrom(s => s.Bank.Tin));
        }
    }
}