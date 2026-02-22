using Bitstore.Application.Services;
using Bitstore.Core.Abstractions;
using Bitstore.DataAccess;
using Bitstore.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<BitstoreDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("BitstoreDbContext"));
});


builder.Services.AddScoped<IBeatRepository, BeatRepository>();
builder.Services.AddScoped<IBeatService, BeatService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapOpenApi();
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
