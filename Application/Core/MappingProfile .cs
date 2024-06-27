using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile ()
        {
            //CreateMap<Domain.Personel,Domain.Personel>();
            CreateMap<Activity,Activity>();
        }
    }
}