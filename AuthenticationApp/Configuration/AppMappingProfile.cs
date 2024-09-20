using AuthenticationApp.DataAccess.Model;
using AuthenticationApp.Models;
using AutoMapper;

namespace AuthenticationApp.Configuration;
public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<User, UserResponse>();
    }
}
