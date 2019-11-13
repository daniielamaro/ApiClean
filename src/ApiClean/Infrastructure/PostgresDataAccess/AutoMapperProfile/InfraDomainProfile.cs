using AutoMapper;

namespace ApiClean.Infrastructure.PostgresDataAccess.AutoMapperProfile
{
    public class InfraDomainProfile : Profile
    {
        public InfraDomainProfile()
        {
            CreateMap<Entities.User.User, Domain.User.User>().ReverseMap();
            CreateMap<Entities.Topic.Topic, Domain.Topic.Topic>().ReverseMap();
            CreateMap<Entities.Comment.Comment, Domain.Comment.Comment>().ReverseMap();
            CreateMap<Entities.Publication.Publication, Domain.Publication.Publication>().ReverseMap();
        }
    }
}
