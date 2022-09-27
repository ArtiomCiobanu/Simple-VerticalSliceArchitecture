using FastEndpoints;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.DataAccess.Context;
using VerticalSliceArchitecture.Features.Users.CreateUser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddDbContext<VerticalSliceContext>(options => options.UseInMemoryDatabase("DBMemory"));

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();

services.AddSwaggerGen();

services.AddFastEndpoints();
services.AddMediatR(typeof(CreateUserCommand));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    SwaggerBuilderExtensions.UseSwagger(app);
    app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "Vertical Slice Architecture v1"));
}
 
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseFastEndpoints();

app.MapControllers();

app.Run();
