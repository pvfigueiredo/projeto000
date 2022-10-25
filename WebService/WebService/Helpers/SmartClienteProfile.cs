using AutoMapper;
using WebService.DTO;
using WebService.Entities;


namespace WebService.Helpers
{
    public class SmartClienteProfile : Profile
    {
        public SmartClienteProfile()
        {
            CreateMap<Cliente, ClienteDTO>()
                .ForMember(
                    dest => dest.NomeCompleto,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.DataNascimento.GetCurrentAge())
                );
        }
    }
}
