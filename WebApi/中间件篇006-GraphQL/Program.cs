using Microsoft.EntityFrameworkCore;
using NET_FiveMinutes_009_GraphQL.Data;
using NET_FiveMinutes_009_GraphQL.GraphQL.Mutation;
using NET_FiveMinutes_009_GraphQL.GraphQL.Query;

var builder = WebApplication.CreateBuilder(args);

// 官方使用文档
https://chillicream.com/docs/hotchocolate/defining-a-schema/mutations

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SqlServer
builder.Services.AddDbContext<AppDbContext>(opt=>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ToolLuConStr"));
});

// GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<QueryToolLus>()
    .AddMutationType<MutationToolLus>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseWebSockets();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL("/graphql");
});

app.Run();
