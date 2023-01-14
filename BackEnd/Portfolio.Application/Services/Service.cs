using AutoMapper;

namespace Portfolio.Application.Services
{
    public abstract class Service
    {
        protected readonly IMapper Mapper;

        public Service(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
