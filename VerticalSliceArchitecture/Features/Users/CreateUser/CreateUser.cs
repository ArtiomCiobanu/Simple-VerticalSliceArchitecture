using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.DataAccess.Context;
using VerticalSliceArchitecture.Domain.Entities;

namespace VerticalSliceArchitecture.Features.Users.CreateUser;

public record class CreateUserCommand(string Email, string FirstName, string LastName) : IRequest<CreateUserResponse>;
public record class CreateUserResponse(bool WasCreated);

public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly VerticalSliceContext _verticalSliceDbContext;
    private readonly IMapper _mapper;

    public CreateUserHandler(VerticalSliceContext verticalSliceDbContext, IMapper mapper)
    {
        _verticalSliceDbContext = verticalSliceDbContext;
        _mapper = mapper;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        if (await _verticalSliceDbContext.Users.AnyAsync(u => u.Email == command.Email, cancellationToken))
        {
            return new CreateUserResponse(false);   
        }

        var user = _mapper.Map<User>(command);
        user.Id = Guid.NewGuid();

        await _verticalSliceDbContext.Users.AddAsync(user, cancellationToken);
        await _verticalSliceDbContext.SaveChangesAsync(cancellationToken);

        return new CreateUserResponse(true);
    }
}

