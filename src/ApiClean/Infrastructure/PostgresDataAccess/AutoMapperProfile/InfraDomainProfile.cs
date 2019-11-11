using AutoMapper;

namespace Infrastructure.PostgresDataAccess.AutoMapperProfile
{
    public class InfraDomainProfile : Profile
    {
        public InfraDomainProfile()
        {
            CreateMap<Entities.Topic.User, Domain.User.User>().ReverseMap();
        }
    }
}
