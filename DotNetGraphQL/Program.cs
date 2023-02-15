using DotNetGraphQL.Database;
using DotNetGraphQL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<ContactContext>(options =>
    {
        options.UseInMemoryDatabase("ContactServer");
    });

builder.Services
    .AddGraphQLServer()    
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

app.MapGraphQL();

app.MapGet("/", () => "🚀 Server ready");

app.Run();