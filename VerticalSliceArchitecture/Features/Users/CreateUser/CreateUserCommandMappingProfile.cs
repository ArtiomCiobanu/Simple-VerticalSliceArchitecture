using AutoMapper;
using VerticalSliceArchitecture.Domain.Entities;

namespace VerticalSliceArchitecture.Features.Users.CreateUser;

public class CreateUserCommandMappingProfile : Profile
{
    public CreateUserCommandMappingProfile() => CreateMap<CreateUserCommand, User>();
}
