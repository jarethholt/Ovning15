using Microsoft.EntityFrameworkCore;
using Tournament.Api.Extensions;
using Tournament.Data.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(opt => opt.ReturnHttpNotAcceptable = true)
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();

builder.Services.AddDbContext<TournamentContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("TournamentConnection"))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

var app = builder.Build();

await app.SeedDataAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
    app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
