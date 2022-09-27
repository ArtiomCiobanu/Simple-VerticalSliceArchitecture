using AutoMapper;

namespace VerticalSliceArchitecture.Features.Users.GetUserDetails;

public class GetUserDetailsResponseMappingProfile : Profile
{
    public GetUserDetailsResponseMappingProfile() => CreateMap<UserController, GetUserDetailsResponse>();
}
