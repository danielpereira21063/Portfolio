using AutoMapper;
using Portfolio.Application.Models.DTOs;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Identity;

namespace Portfolio.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<DadosPortfolio, DadosPortfolioDto>().ReverseMap();
            CreateMap<Projeto, ProjetoDto>().ReverseMap();
            CreateMap<ImagemProjeto, ImagemProjetoDto>().ReverseMap();
        }
    }
}
