using AutoMapper;
using Portfolio.Application.Models.DTOs;
using Portfolio.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Services
{
    public class HabilidadeService : Service, IHabilidadeService
    {
        public HabilidadeService(IMapper mapper) : base(mapper)
        {
            
        }

        public ICollection<HabilidadeDto> ObterLista(int dadosPortfolioId)
        {

        }
    }
}
