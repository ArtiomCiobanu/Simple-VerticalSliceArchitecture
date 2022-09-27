using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.DataAccess.Context;

namespace VerticalSliceArchitecture.Features.Users.GetUserDetails;

public class GetUserDetailsQuery
{
    public string Email { get; init; } = null!;
}

public class GetUserDetailsResponse
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
}

public class GetUserDetailsHandler : Endpoint<GetUserDetailsQuery, GetUserDetailsResponse>
{
    private readonly VerticalSliceContext _verticalSliceContext;
    private readonly AutoMapper.IMapper _mapper;

    public GetUserDetailsHandler(
        VerticalSliceContext verticalSliceDbContext,
        AutoMapper.IMapper mapper)
    {
        _verticalSliceContext = verticalSliceDbContext;
        _mapper = mapper;
    }

    public override void Configure()
    {
        Get("/users/{Email}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        GetUserDetailsQuery req, 
        CancellationToken cancellationToken)
    {
        var foundUser = await _verticalSliceContext.Users
            .FirstOrDefaultAsync(u => u.Email == req.Email, cancellationToken);

        await (foundUser == null
            ? SendOkAsync(_mapper.Map<GetUserDetailsResponse>(foundUser), cancellationToken)
            : SendNoContentAsync(cancellationToken));
    }
}
