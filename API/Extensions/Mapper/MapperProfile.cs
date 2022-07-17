using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserCreateDTO>().ReverseMap();
        CreateMap<User, UserDeleteDTO>().ReverseMap();
        CreateMap<User, LoginDTO>().ReverseMap();
    }
}