using AutoMapper;
using Portfolio.Application.Models.DTOs;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DadosPortfolio, DadosPortfolioDto>().ReverseMap();
            CreateMap<Projeto, ProjetoDto>().ReverseMap();
            CreateMap<ImagemProjeto, ImagemProjetoDto>().ReverseMap();
        }
    }
}
